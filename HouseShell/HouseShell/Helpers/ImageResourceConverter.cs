using System;
using Xamarin.Forms;

namespace HouseShell.Helpers
{
    public class ImageResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Could use reflection, but overkill here
            return ImageSource.FromResource("HouseShell.Images." + (value ?? ""));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
