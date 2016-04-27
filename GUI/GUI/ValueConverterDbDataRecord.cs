using System;
using System.Data.Common;
using System.Globalization;
using System.Windows.Data;

namespace GUI
{
    public class ValueConverterDbDataRecord:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DbDataRecord d = value as DbDataRecord;
            if (d == null)
                return null;
            object r = d.GetValue(System.Convert.ToInt32(parameter));
            return r;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
