using System.Globalization;
using JikanDotNet;

namespace AniPlug.Converters;

public class JikanGenreConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var names = new List<string>();
        if (value is ICollection<MalUrl> genres)
        {
            foreach (var genre in genres) names.Add(genre.Name);

            return string.Join(" • ", names.Take(2));
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}