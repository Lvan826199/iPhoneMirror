"""Wireless DDI preflight and USB preparation must preserve usable routes."""
import sys
import unittest
from pathlib import Path
from types import SimpleNamespace
from unittest.mock import AsyncMock, patch

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / 'tools'))
import usb_touch_bridge as bridge


class WirelessDdiFallbackTests(unittest.IsolatedAsyncioTestCase):
    def session(self, transport='wireless'):
        return bridge.TouchSession(SimpleNamespace(emit=AsyncMock()), 120, 'test-device', transport)

    async def test_unavailable_network_image_service_still_probes_control_tunnel(self):
        session = self.session()
        lockdown = SimpleNamespace(udid='test-device')
        error = bridge.BridgePrerequisiteError('developer_image_service_unavailable', 'USB-only service')
        with patch.object(session, '_preflight_developer_environment', AsyncMock(side_effect=error)), \
             patch.object(session, '_run_tunnel_attempt', AsyncMock()) as tunnel:
            await session._connect_with_lockdown(lockdown)
            tunnel.assert_awaited_once_with(lockdown)

    async def test_preflight_failure_does_not_bypass_device_or_network_errors(self):
        for mode, code in [('usb', 'developer_image_service_unavailable'),
                           ('wireless', 'apple_device_locked'), ('wireless', 'apple_device_not_trusted'),
                           ('wireless', 'developer_mode_required'), ('wireless', 'apple_connection_lost'),
                           ('wireless', 'developer_image_tss_timeout'),
                           ('wireless', 'developer_image_service_timeout')]:
            session = self.session(mode)
            session._remote_pairing_provision_attempted = True
            error = bridge.BridgePrerequisiteError(code, 'preflight failed')
            with self.subTest(mode=mode, code=code), \
                 patch.object(session, '_preflight_developer_environment', AsyncMock(side_effect=error)), \
                 patch.object(session, '_run_tunnel_attempt', AsyncMock()) as tunnel:
                with self.assertRaises(bridge.BridgePrerequisiteError) as raised:
                    await session._connect_with_lockdown(SimpleNamespace(udid='test-device'))
                self.assertIs(raised.exception, error)
                tunnel.assert_not_awaited()

    async def test_legacy_wireless_missing_hid_prepares_usb_before_rebuilding_network(self):
        session = self.session()
        session._ddi_was_mounted = True
        missing = bridge.BridgePrerequisiteError('touch_surface_unavailable', 'missing HID')
        with patch.object(session, '_connect_with_lockdown', AsyncMock(side_effect=[missing, None])) as connect, \
             patch.object(session, '_prepare_ddi_for_remote_pairing', AsyncMock()) as usb, \
             patch.object(session, '_refresh_personalized_ddi', AsyncMock()) as network_refresh:
            await session._connect_with_ddi_recovery(object())
            usb.assert_awaited_once()
            network_refresh.assert_not_awaited()
            self.assertEqual(connect.await_count, 2)
            self.assertEqual(session.transport_mode, 'wireless')

    async def test_existing_network_image_can_skip_unavailable_inventory_without_usb(self):
        session = self.session()
        lockdown = SimpleNamespace(udid='test-device')
        with patch.object(session, '_preflight_developer_environment', AsyncMock(side_effect=
                bridge.BridgePrerequisiteError('developer_image_service_unavailable', 'USB-only'))), \
             patch.object(session, '_run_tunnel_attempt', AsyncMock()) as tunnel, \
             patch.object(session, '_prepare_ddi_for_remote_pairing', AsyncMock()) as usb:
            await session._connect_with_ddi_recovery(lockdown)
            tunnel.assert_awaited_once_with(lockdown)
            usb.assert_not_awaited()

    async def test_legacy_network_inventory_error_prepares_exact_usb_then_retries_wireless(self):
        session = self.session()
        network = SimpleNamespace(udid='test-device', product_version='26.0',
                                  get_developer_mode_status=AsyncMock(return_value=True))
        usb = SimpleNamespace(udid=network.udid, product_version=network.product_version,
                              get_developer_mode_status=AsyncMock(return_value=True), close=AsyncMock())
        # Exercise the real SDK inventory query: opening Network's image
        # service works, but its LookupImage command rejects the endpoint.
        connection = SimpleNamespace(send_recv_plist=AsyncMock(side_effect=
            bridge.InvalidServiceError('InvalidService', 'test-device', '26.0')), close=AsyncMock())
        network.start_lockdown_service = AsyncMock(return_value=connection)
        query = bridge.TouchSession._query_personalized_ddi_inventory
        async def inventory(lockdown):
            if lockdown is network:
                return await query(lockdown)
            self.assertIs(lockdown, usb)
            return True
        missing = bridge.BridgePrerequisiteError('touch_surface_unavailable', 'missing HID')
        with patch.object(bridge.TouchSession, '_query_personalized_ddi_inventory', inventory), \
             patch.object(session, '_create_lockdown_with_retry', AsyncMock(return_value=usb)) as create, \
             patch.object(session, '_refresh_personalized_ddi', AsyncMock()) as refresh, \
             patch.object(session, '_run_tunnel_attempt', AsyncMock(side_effect=[missing, None])) as tunnel:
            await session._connect_with_ddi_recovery(network)
            create.assert_awaited_once_with('USB')
            refresh.assert_awaited_once_with(usb)
            self.assertEqual([call.args[0] for call in tunnel.await_args_list], [network, network])
            usb.close.assert_awaited_once()
            self.assertEqual(connection.close.await_count, 2)

    async def test_usb_preparation_failure_is_reported_without_repeating_wireless(self):
        session = self.session()
        error = bridge.BridgePrerequisiteError('developer_image_required', 'connect USB')
        with patch.object(session, '_connect_with_lockdown', AsyncMock(side_effect=
                bridge.BridgePrerequisiteError('touch_surface_unavailable', 'missing HID'))) as connect, \
             patch.object(session, '_prepare_ddi_for_remote_pairing', AsyncMock(side_effect=error)):
            with self.assertRaises(bridge.BridgePrerequisiteError) as raised:
                await session._connect_with_ddi_recovery(object())
            self.assertIs(raised.exception, error)
            connect.assert_awaited_once()


if __name__ == '__main__':
    unittest.main()
