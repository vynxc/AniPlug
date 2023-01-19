using System.Globalization;
using AniPlug.API_Wrappers.Consumet.Models;

namespace AniPlug.Converters;

public class TitlesConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Title titles)
        {
            if (!string.IsNullOrEmpty(titles.english))
                return titles.english;
            if (!string.IsNullOrEmpty(titles.romaji))
                return titles.romaji;
            if (!string.IsNullOrEmpty(titles.native))
                return titles.native;
            if (!string.IsNullOrEmpty(titles.userPreferred))
                return titles.userPreferred;
            return "Sorry, Cant Get Title.";
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}