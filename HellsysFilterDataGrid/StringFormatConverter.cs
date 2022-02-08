using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace HellsysFilterDataGrid
{
    public class StringFormatConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                // values [0] contains the format
                if (values[0] == DependencyProperty.UnsetValue || string.IsNullOrEmpty(values[0]?.ToString()))
                    return string.Empty;

                var stringFormat = values[0].ToString();

                return string.Format(stringFormat, values.Skip(1).ToArray());
            }
            catch (FormatException ex)
            {
                Debug.WriteLine($"StringFormatConverter.Convert error: {ex.Message}");
                return string.Empty;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
