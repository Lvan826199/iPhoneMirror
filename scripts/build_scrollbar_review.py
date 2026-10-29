"""Build a local, offline review album from shown-window PNG exports."""

import argparse
import html
import json
import re
from pathlib import Path
import xml.etree.ElementTree as ET


LABELS = {
    "MainWindow": "主工作区", "AboutWindow": "关于 / 诊断日志", "DeveloperToolsWindow": "开发者工具",
    "DeviceBindingWindow": "设备管理", "ImageSettingsWindow": "画面设置", "MediaOutputSettingsWindow": "媒体输出",
    "ProjectionSettingsWindow": "投屏设置", "ReverseControlStatusWindow": "反控状态",
    "ShortcutSettingsWindow": "快捷键设置", "UpdateWindow": "更新 / 发布说明",
    "UsbProjectionModeInfoWindow": "USB 模式说明", "CaptureStatusNoticeWindow": "采集与控制错误提示",
    "AdvancedSettingsWindow": "高级设置", "AppPromptWindow": "操作确认", "AirPlayDeviceSelectionWindow": "AirPlay 设备选择",
    "BluetoothClientBindingWindow": "蓝牙客户端绑定", "BluetoothConnectionWindow": "蓝牙连接",
    "BluetoothControlNoticeWindow": "蓝牙操作提示", "CaptureRecoveryWindow": "采集恢复",
    "ComponentDownloadWindow": "组件下载", "InstanceConflictWindow": "实例冲突",
    "ProtectedContentNoticeWindow": "受保护内容提示", "StartupErrorWindow": "启动错误",
    "TextInputWindow": "文本输入", "WindowStyleSettingsWindow": "窗口样式",
    "KeyboardMappingEditorWindow": "按键映射编辑 / 五步向导", "KeyboardMappingWindow": "按键映射列表",
    "KeyboardMappingOverlayWindow": "按键映射 · 位置选取覆盖层",
    "FirstRunSetupWindow": "首次设置 / 检查清单", "TrayPanelWindow": "托盘面板",
    "DeviceTrustWindow": "驱动 · 信任设备", "FailureHelpWindow": "驱动 · 故障帮助",
    "ParentDriverWindow": "驱动 · 父驱动管理", "PromptWindow": "驱动 · 操作确认",
    "RequiredActionWindow": "驱动 · 必需操作",
}
GROUP_ORDER = list(LABELS)
STATE_LABELS = {
    'invalid': '输入错误提示',
    'record-idle': '录制 · 待开始', 'record-running': '录制 · 运行中',
    'stream-running': '直播 · 运行中', 'camera-running': '虚拟摄像头 · 运行中',
    'workspace-mirroring': '投屏工作区', 'workspace-devices': '设备工作区',
    'workspace-settings': '侧边投屏设置', 'workspace-output': '媒体输出工作区', 'workspace-toolbar': '投屏工具栏',
    'about': '关于', 'developer-tools': '开发者工具', 'device-binding': '设备管理',
    'image-settings': '画面设置', 'media-output': '媒体输出', 'projection-settings': '投屏设置',
    'shortcut-settings': '快捷键设置', 'update': '更新说明', 'usb-mode': 'USB 模式说明',
    'advanced-settings': '高级设置', 'text-input': '文本输入', 'startup-error': '启动错误',
    'reverse-control-status': '反控状态', 'reverse-control-prompt-long': '反控长说明',
    'reverse-control-prompt': '反控确认', 'capture-error': '采集错误', 'reverse-control-error': '反控错误',
    'session-closed': '会话结束', 'usb-config-error': 'USB 配置错误', 'prompt-long': '长确认文案',
    'prompt': '操作确认', 'instance-conflict': '实例冲突', 'protected-content': '受保护内容',
    'Welcome': '欢迎', 'Preferences': '偏好设置', 'ApplicationMode': '运行方式', 'Appearance': '外观',
    'Usage': '使用方式', 'Mirroring': '投屏体验', 'Environment': '环境准备', 'Connection': '连接方式',
    'Display': '显示设置', 'Wireless': '无线投屏', 'WiredFrameRate': '有线帧率', 'WiredDisplay': '有线画面',
    'WiredDecoder': '有线解码', 'WiredColor': '有线颜色', 'WiredProjection': '有线投屏模式',
    'Profile': '设备档案', 'Validation': '设备验证', 'ReDetection': '重新检测',
    'DeviceComplete': '设备完成', 'ControlReadiness': '控制准备', 'ControlIntroduction': '控制介绍',
    'Completed': '设置完成', 'KeySelection': '选择按键', 'ActionSelection': '选择动作',
    'Parameter': '动作参数', 'Position': '目标位置', 'Confirmation': '确认映射',
    'driver-simple': '驱动管理器简洁页', 'driver-advanced': '驱动管理器高级页',
    'DriverRefreshFailed': '刷新失败', 'DriverWaitingSafeStop': '等待安全停止',
    'DriverProbeFailed': '诊断失败', 'DriverOperationFailed': '操作失败',
}

HTML = r'''<!doctype html>
<html lang="zh-CN"><meta charset="utf-8"><meta name="viewport" content="width=device-width,initial-scale=1">
<title>滚动条 · 逐窗截图审查</title>
<style>
:root{color-scheme:light;--ink:#162438;--muted:#647286;--line:#dce3eb;--accent:#1267d5}
*{box-sizing:border-box}body{margin:0;background:#f3f6fa;color:var(--ink);font:15px/1.5 "Segoe UI","Microsoft YaHei UI",sans-serif}
header{padding:28px 32px 20px;background:white;border-bottom:1px solid var(--line)}h1{font-size:28px;margin:0 0 7px}p{margin:5px 0;color:var(--muted)}
.toolbar{padding:15px 32px;display:flex;gap:10px;align-items:center;flex-wrap:wrap;background:#fff;position:sticky;top:0;z-index:2;border-bottom:1px solid var(--line)}
select,input,button{font:inherit;border:1px solid var(--line);border-radius:8px;padding:8px 11px;background:white;color:var(--ink)}button{cursor:pointer}button:hover{border-color:var(--accent)}button.primary{background:var(--accent);color:white;border-color:var(--accent)}input{min-width:200px}button:focus-visible,select:focus-visible,input:focus-visible{outline:3px solid #9ec8ff;outline-offset:2px}
.count{margin-left:auto;color:var(--muted)}main{padding:25px 32px 60px}.grid{display:grid;grid-template-columns:repeat(auto-fill,minmax(320px,1fr));gap:22px}.card{padding:0;text-align:left;overflow:hidden;background:white;border:1px solid var(--line);border-radius:13px;box-shadow:0 3px 12px #193c6a06}.preview{height:240px;background:#e9edf3;display:flex;align-items:center;justify-content:center;padding:10px}.preview img{max-width:100%;max-height:100%;object-fit:contain;box-shadow:0 3px 15px #16243815}.caption{padding:16px}.caption strong{font-size:17px;display:block}.caption small{display:block;color:var(--muted);margin-top:5px}.badge{float:right;color:#ac6a00;font-weight:600}.notice{padding:12px 15px;margin:0 0 18px;border:1px solid #e6cf94;border-radius:9px;background:#fff9e9;color:#745514}.empty{padding:50px;text-align:center;color:var(--muted)}
dialog{padding:0;border:0;border-radius:12px;width:96vw;height:95vh;max-width:none;max-height:none;background:#e7ecf2;box-shadow:0 12px 60px #001b3b40}dialog::backdrop{background:#172638bf}.viewer{height:100%;display:flex;flex-direction:column}.viewerbar{display:flex;gap:9px;align-items:center;flex-wrap:wrap;padding:12px 16px;background:white;border-bottom:1px solid var(--line)}.viewerbar h2{font-size:18px;margin:0 auto 0 0}.viewerbar select{max-width:52vw}.canvas{flex:1;min-height:0;overflow:auto;display:flex;align-items:flex-start;justify-content:center;padding:20px}.canvas img{max-width:100%;max-height:100%;object-fit:contain;align-self:center;box-shadow:0 4px 30px #10283e20}.canvas.actual{display:block}.canvas.actual img{max-width:none;max-height:none;display:block;margin:auto}.foot{background:white;padding:10px 16px;border-top:1px solid var(--line);display:flex;gap:12px;align-items:center;flex-wrap:wrap}.foot small{color:var(--muted)}.foot input{flex:1}.path{font-size:11px;overflow-wrap:anywhere;color:var(--muted)}.mark{color:#a46a00}.guide{font-size:13px}a{color:var(--accent)}
@media(max-width:650px){header,.toolbar,main{padding-left:15px;padding-right:15px}.grid{grid-template-columns:1fr}.count{margin-left:0}.viewerbar select{max-width:95vw}.preview{height:230px}}
</style>
<header><h1>滚动条 · 逐窗截图审查</h1>
<p id="intro"></p><p class="guide">点击窗口进入相册；← → 逐张翻阅，Esc 返回。可按窗口、主题、字号筛选，也可在图下标记问题并导出审查记录。</p>
<p class="guide">画面来源：逐一显示的实际 WPF 窗口，以 RenderTargetBitmap 导出窗口内容；不是桌面截屏。错误、下载及驱动操作使用预览数据。</p></header>
<div class="toolbar"><input id="search" type="search" placeholder="搜索窗口 / 状态" aria-label="搜索窗口">
<select id="window" aria-label="窗口"><option value="">全部窗口</option></select><select id="theme" aria-label="主题"><option value="">全部主题</option><option>Light</option><option>Dark</option></select>
<select id="scale" aria-label="文字大小"><option value="">全部字号</option><option value="1">100%</option><option value="2">200%</option></select>
<button id="start" class="primary">从第一张开始</button><button id="scrolling">只看滚动条出现</button><button id="marked">只看已标记</button><button id="export">导出审查记录</button><span id="count" class="count"></span></div>
<main><div id="pending"></div><div id="grid" class="grid"></div></main>
<dialog id="modal"><div class="viewer"><div class="viewerbar"><h2 id="heading"></h2><button id="prev">← 上一张</button><button id="next">下一张 →</button><select id="variants" aria-label="当前窗口的截图状态"></select><button id="zoom">原始大小</button><button id="close">关闭 ×</button></div>
<div id="canvas" class="canvas"><img id="large" alt="窗口截图"></div><div class="foot"><span id="position"></span><button id="flag">标记有问题</button><input id="note" placeholder="这张图哪里需要改？" aria-label="审查备注"><a id="original" target="_blank">打开原图</a><small id="dimensions"></small><span id="filepath" class="path"></span></div></div></dialog>
<script id="review-data" type="application/json">__DATA__</script>
<script>
const data=JSON.parse(document.getElementById('review-data').textContent),items=data.items,$=id=>document.getElementById(id);
let notes={};try{notes=JSON.parse(localStorage.getItem('iphone-scrollbar-review-v1')||'{}')}catch(e){}
let filtered=[],current=-1,markedOnly=false,scrollingOnly=false;const save=()=>localStorage.setItem('iphone-scrollbar-review-v1',JSON.stringify(notes));
const groups=[...new Set(items.map(x=>x.group))];for(const g of groups){const o=document.createElement('option');o.value=g;o.textContent=items.find(x=>x.group===g).label;$('window').append(o)}
$('intro').textContent=`${data.windowCount} 类窗口 · ${items.length} 张截图 · 简体中文 · 正常 / 200% 字号 · 深浅主题`;
if(data.missing.length)$('pending').textContent='尚未收集：'+data.missing.join('、');if(data.missing.length)$('pending').className='notice';
function label(x){return `#${x.id} · ${x.theme==='Light'?'浅色':x.theme==='Dark'?'深色':'主题未记录'} · ${Math.round(x.scale*100)}% · ${x.state}`}
function draw(){const q=$('search').value.toLowerCase();filtered=items.filter(x=>(!$('window').value||x.group===$('window').value)&&(!$('theme').value||x.theme===$('theme').value)&&(!$('scale').value||String(x.scale)===$('scale').value)&&(!markedOnly||notes[x.id]?.flag)&&(!scrollingOnly||x.bars>0)&&(!q||`${x.label} ${x.state} ${x.file} ${x.id}`.toLowerCase().includes(q)));
 $('count').textContent=`${new Set(filtered.map(x=>x.group)).size} 类窗口 / ${filtered.length} 张`;$('grid').replaceChildren();
 for(const g of groups){const candidates=filtered.filter(x=>x.group===g);if(!candidates.length)continue;const x=[...candidates].sort((a,b)=>a.rank-b.rank||a.id-b.id)[0];const b=document.createElement('button');b.className='card';b.setAttribute('aria-label',x.label);const p=document.createElement('div');p.className='preview';const im=document.createElement('img');im.src=x.file;im.loading='lazy';im.alt=x.label;p.append(im);const cap=document.createElement('div');cap.className='caption';const title=document.createElement('strong');title.textContent=x.label;const small=document.createElement('small');small.textContent=`${candidates.length} 张 · ${label(x)}`;cap.append(title,small);if(candidates.some(t=>notes[t.id]?.flag)){const mark=document.createElement('span');mark.className='badge';mark.textContent='已标记';cap.prepend(mark)}b.append(p,cap);b.onclick=()=>open(filtered.indexOf(x));$('grid').append(b)}
 if(!filtered.length){const e=document.createElement('p');e.className='empty';e.textContent='没有符合条件的截图';$('grid').append(e)}}
function open(i){if(!filtered.length)return;current=(i+filtered.length)%filtered.length;const x=filtered[current];$('heading').textContent=x.label;$('large').src=x.file;$('large').alt=x.label+' '+label(x);$('position').textContent=`${current+1} / ${filtered.length} · #${x.id}`;$('dimensions').textContent=`${x.width} × ${x.height}`;$('filepath').textContent=x.file;$('original').href=x.file;$('note').value=notes[x.id]?.note||'';$('flag').textContent=notes[x.id]?.flag?'✓ 已标记有问题':'标记有问题';$('variants').replaceChildren();for(const y of filtered.filter(t=>t.group===x.group)){const o=document.createElement('option');o.value=filtered.indexOf(y);o.textContent=label(y);o.selected=y.id===x.id;$('variants').append(o)}if(!$('modal').open)$('modal').showModal();$('canvas').scrollTop=0;$('canvas').scrollLeft=0;location.hash='shot-'+x.id}
for(const id of ['search','window','theme','scale'])$(id).addEventListener(id==='search'?'input':'change',draw);$('start').onclick=()=>open(0);$('prev').onclick=()=>open(current-1);$('next').onclick=()=>open(current+1);$('close').onclick=()=>$('modal').close();$('variants').onchange=()=>open(Number($('variants').value));$('zoom').onclick=()=>{$('canvas').classList.toggle('actual');$('zoom').textContent=$('canvas').classList.contains('actual')?'适应窗口':'原始大小'};
$('flag').onclick=()=>{const id=filtered[current].id;notes[id]={...notes[id],flag:!notes[id]?.flag};save();$('flag').textContent=notes[id].flag?'✓ 已标记有问题':'标记有问题'};$('note').oninput=()=>{const id=filtered[current].id;notes[id]={...notes[id],note:$('note').value,flag:true};save();$('flag').textContent='✓ 已标记有问题'};$('modal').addEventListener('close',draw);
$('marked').onclick=()=>{markedOnly=!markedOnly;$('marked').textContent=markedOnly?'显示全部':'只看已标记';draw()};$('export').onclick=()=>{const entries=items.filter(x=>notes[x.id]?.flag||notes[x.id]?.note).map(x=>({number:x.id,window:x.label,screenshot:x.file,...notes[x.id]}));const blob=new Blob([JSON.stringify({reviewedAt:new Date().toISOString(),entries},null,2)],{type:'application/json'});const a=document.createElement('a');a.href=URL.createObjectURL(blob);a.download='scrollbar-review-notes.json';a.click();setTimeout(()=>URL.revokeObjectURL(a.href),1000)};
$('scrolling').onclick=()=>{scrollingOnly=!scrollingOnly;$('scrolling').textContent=scrollingOnly?'显示全部滚动状态':'只看滚动条出现';draw()};
document.addEventListener('keydown',e=>{if(!$('modal').open||['INPUT','TEXTAREA','SELECT'].includes(document.activeElement.tagName))return;if(e.key==='ArrowRight'){e.preventDefault();open(current+1)}if(e.key==='ArrowLeft'){e.preventDefault();open(current-1)}});draw();const initial=Number(location.hash.replace('#shot-',''));if(initial){const i=filtered.findIndex(x=>x.id===initial);if(i>=0)open(i)}
</script></html>'''


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('directory', type=Path)
    args = parser.parse_args()
    output = args.directory.resolve()
    source = Path(__file__).resolve().parents[1]
    captures = output / 'captures'
    rows = []
    for sidecar in captures.rglob('*.capture.json'):
        png = sidecar.with_name(sidecar.name.replace('.capture.json', '.png'))
        if not png.exists():
            continue
        meta = json.loads(sidecar.read_text(encoding='utf-8-sig'))
        group = meta['windowType']
        driver = 'DriverInstaller' in group
        name = meta['window']
        label = '驱动管理器' if driver and name == 'MainWindow' else LABELS.get(name, name)
        filename = png.stem
        theme = 'Dark' if re.search(r'(?:^|-|_)Dark(?:-|_|$)', filename) else 'Light' if re.search(r'(?:^|-|_)Light(?:-|_|$)', filename) else 'Unspecified'
        scale = 2 if (meta.get('bodyFontSize') or 14) >= 24 else 1
        rank = (0 if theme == 'Light' else 100) + (0 if scale == 1 else 30)
        rank += 15 if 'small' in filename or '200pct' in filename or '-600-' in filename else 0
        rank += 6 if '-tab-' in filename or '-expanded-' in filename else 0
        rank += 4 if '-invalid' in filename else 0
        state = re.sub(r'^zh-CN-(?:Light|Dark)-', '', filename)
        for token, translated in sorted(STATE_LABELS.items(), key=lambda pair: -len(pair[0])):
            state = state.replace(token, translated)
        state = state.replace('200pct', '小窗口').replace('-small', ' / 小窗口').replace('-default', ' / 默认窗口').replace('-tab-', ' / 页签 ').replace('-expanded-', ' / 展开区 ')
        rows.append(dict(group=group, label=label, theme=theme, scale=scale, state=state,
                         file=png.relative_to(output).as_posix(), rank=rank,
                         width=round(meta['width']), height=round(meta['height']),
                         bars=sum(area['vertical'] == 'Visible' or area['horizontal'] == 'Visible' for area in meta.get('scrollAreas', []))))
    def key(row):
        name = row['group'].split('.')[-1]
        order = GROUP_ORDER.index(name) if name in GROUP_ORDER else 999
        if 'DriverInstaller' in row['group']:
            order += 100
        return order, row['group'], row['rank'], row['file']
    rows.sort(key=key)
    for index, row in enumerate(rows, 1):
        row['id'] = index
    captured_types = {row['group'] for row in rows}
    expected = []
    for folder in ('src/App', 'src/DriverInstaller'):
        for path in (source / folder).rglob('*.xaml'):
            if any(part in ('obj', 'bin') for part in path.parts):
                continue
            root = ET.parse(path).getroot()
            if root.tag.split('}')[-1] not in ('Window', 'RoundedWindow'):
                continue
            class_name = root.attrib.get('{http://schemas.microsoft.com/winfx/2006/xaml}Class')
            if class_name:
                expected.append(class_name)
    missing = sorted(set(expected) - captured_types)
    data = dict(windowCount=len(captured_types), screenshotCount=len(rows), items=rows,
                missing=missing, expected=sorted(expected), captureMethod='Shown WPF window RenderTargetBitmap export')
    output.mkdir(parents=True, exist_ok=True)
    (output / 'manifest.json').write_text(json.dumps(data, ensure_ascii=False, indent=2), encoding='utf-8')
    (output / 'index.html').write_text(HTML.replace('__DATA__', json.dumps(data, ensure_ascii=False).replace('</', '<\\/')), encoding='utf-8')
    groups = []
    for row in rows:
        if row['group'] not in [group['group'] for group in groups]:
            groups.append(row)
    lines = ['# 滚动条逐窗截图审查', '', f'共 {len(captured_types)} 类窗口、{len(rows)} 张截图。', '',
             '截图来自逐一显示的实际 WPF 窗口渲染导出，不是桌面截屏。错误、驱动和下载页面使用预览状态。', '',
             f'[打开可离线使用的审查相册]({(output / "index.html").as_posix()})', '']
    for row in groups:
        lines.extend([f"## {row['label']}", '', f"代表截图 #{row['id']}；相册中可切换该窗口的主题、字号和状态。", '', f"![{row['label']}]({(output / row['file']).as_posix()})", ''])
    if missing:
        lines.extend(['尚未收集：' + '、'.join(missing), ''])
    (output / '审查清单.md').write_text('\n'.join(lines), encoding='utf-8')
    print(json.dumps({k: data[k] for k in ('windowCount', 'screenshotCount', 'missing')}, ensure_ascii=False))


if __name__ == '__main__':
    main()
