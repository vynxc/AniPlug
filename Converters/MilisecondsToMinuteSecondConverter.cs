using System.Globalization;

namespace AniPlug.Converters;

public class MilisecondsToMinuteSecondConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            Console.WriteLine($"Value: {value}, Type: {value?.GetType()}");
            if (value == null) return "--:--";

            var miliseconds = (double)value;
            var minutes = (int)miliseconds / 60000;
            var seconds = (int)(miliseconds % 60000) / 1000;
            return $"{minutes:D2}:{seconds:D2}";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in MilisecondsToMinuteSecondConverter: {ex.Message}");
            return value;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return "--:--";
    }
}