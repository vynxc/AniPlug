using System.Globalization;
using JikanDotNet;

namespace AniPlug.Converters;

public class JikanTitlesConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is ICollection<TitleEntry> titles)
            return titles.FirstOrDefault(title => title.Type == "English")?.Title ??
                   titles.FirstOrDefault(title => title.Type == "Default")?.Title;

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}