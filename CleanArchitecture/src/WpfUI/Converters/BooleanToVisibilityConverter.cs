using System.Windows;

namespace WpfUI.Converters;

public class BooleanToVisibilityConverter : BooleanConverter<Visibility>
{
    public BooleanToVisibilityConverter() : base(Visibility.Visible, Visibility.Collapsed)
    { }
}
