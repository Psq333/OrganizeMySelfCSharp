using OrganizeMySelf.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace OrganizeMySelf.Views
{
    public class BoolToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush colore = Brushes.LightGreen;
            if ((InsideStorage)value[0] == InsideStorage.Outside) colore = Brushes.PaleVioletRed;
            if ((int)value[1] == 0) colore = Brushes.Yellow;
            return colore;
        }

        public object ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
