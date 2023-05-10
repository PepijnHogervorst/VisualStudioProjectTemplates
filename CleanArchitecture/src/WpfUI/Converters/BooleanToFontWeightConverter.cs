using System.Windows;

namespace WpfUI.Converters;

internal class BooleanToFontWeightConverter : BooleanConverter<FontWeight>
{
    public BooleanToFontWeightConverter() : base(FontWeights.Bold, FontWeights.Normal)
    {

    }
}
