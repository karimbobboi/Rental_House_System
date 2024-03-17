using System;
using System.Globalization;

namespace Rental_House_System
{
	public class AgentEmailToNameConverter : IValueConverter
    {
        App globalref = (App)Application.Current;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value is null or not a string
            if (value == null || value is not string)
                return null;

            return globalref.appDB.GetAgentByEmail((string)value).name; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // This converter doesn't support converting back
            throw new NotSupportedException();
        }
        
	}
}

