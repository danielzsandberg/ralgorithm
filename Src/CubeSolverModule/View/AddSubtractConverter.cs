using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RubiksApp.CubeSolverModule.View
{
    public class AddSubtractConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int valueToAddSubtractFrom = System.Convert.ToInt32(value);
            int amountToAddSubtractBy = System.Convert.ToInt32(parameter);

            return valueToAddSubtractFrom + amountToAddSubtractBy;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int valueToAddSubtractFrom = System.Convert.ToInt32(value);
            int amountToAddSubtractBy = System.Convert.ToInt32(parameter);

            return valueToAddSubtractFrom - amountToAddSubtractBy;
        }
    }
}
