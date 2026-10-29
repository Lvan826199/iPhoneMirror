using System.Windows;
using System.Windows.Controls;

namespace IPhoneMirror.UI.Controls;

/// <summary>A label, editor and trailing action; enlarged text uses a full-width label above the editor.</summary>
public sealed class ResponsiveFieldRow : Panel
{
    private bool _stacked;
    private double _labelWidth, _labelHeight, _editorHeight, _actionWidth;

    protected override Size MeasureOverride(Size availableSize)
    {
        if (InternalChildren.Count != 3) return base.MeasureOverride(availableSize);
        var width = double.IsInfinity(availableSize.Width) ? 520 : availableSize.Width;
        var label = InternalChildren[0];
        var editor = InternalChildren[1];
        var action = InternalChildren[2];
        action.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        _actionWidth = action.DesiredSize.Width;
        var fontScale = label is TextBlock text ? text.FontSize / 14 : 1;
        _stacked = width < 160 * fontScale + 120 * fontScale + _actionWidth + 20;
        _labelWidth = _stacked ? width : Math.Min(180 * fontScale, width * .44);
        label.Measure(new Size(_labelWidth, double.PositiveInfinity));
        editor.Measure(new Size(Math.Max(0, width - (_stacked ? 0 : _labelWidth + 12) - _actionWidth - 8), double.PositiveInfinity));
        _labelHeight = label.DesiredSize.Height;
        _editorHeight = Math.Max(editor.DesiredSize.Height, action.DesiredSize.Height);
        return new Size(width, _stacked ? _labelHeight + 6 + _editorHeight : Math.Max(_labelHeight, _editorHeight));
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        if (InternalChildren.Count != 3) return base.ArrangeOverride(finalSize);
        var top = _stacked ? _labelHeight + 6 : 0;
        var editorLeft = _stacked ? 0 : _labelWidth + 12;
        InternalChildren[0].Arrange(new Rect(0, 0, _labelWidth, _stacked ? _labelHeight : finalSize.Height));
        InternalChildren[1].Arrange(new Rect(editorLeft, top, Math.Max(0, finalSize.Width - editorLeft - _actionWidth - 8), _editorHeight));
        InternalChildren[2].Arrange(new Rect(Math.Max(0, finalSize.Width - _actionWidth), top, _actionWidth, _editorHeight));
        return finalSize;
    }
}
