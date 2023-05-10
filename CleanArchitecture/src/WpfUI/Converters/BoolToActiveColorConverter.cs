using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfUI.Converters;

public class BoolToActiveColorConverter : IValueConverter
{
    private readonly Brush _inactiveBrush = Brushes.Gray;
    private readonly Brush _activeBrush = Brushes.Green;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not bool boolVal) return _inactiveBrush;
        if (!boolVal) return _inactiveBrush;

        return _activeBrush;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
