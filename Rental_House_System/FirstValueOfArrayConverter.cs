using System;
using System.Globalization;

namespace Rental_House_System
{
	
    public class FirstValueOfArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is null or not a string
            if (value == null || value is not string)
                return null;

            // Split the string by commas and remove any leading or trailing whitespace
            string[] values = ((string)value).Split(',').Select(s => s.Trim()).ToArray();

            return values[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter doesn't support converting back
            throw new NotSupportedException();
        }
    }
    
}

