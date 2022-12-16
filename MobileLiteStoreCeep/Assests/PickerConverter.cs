using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLiteStoreCeep.Assests
{
    public class PickerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Go from the currency to "symbol [name]":
            //Country model = value as Country;
            //return $"{model.name}";
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Go from "symbol [name]" to the currency:
            //return Commons.Currencies.Where(x => x.symbol.Equals((value as string).Split(' ')[0]));
            return value.ToString();
        }
    }
}
