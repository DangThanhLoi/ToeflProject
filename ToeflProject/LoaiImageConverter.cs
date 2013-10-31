using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ToeflProject
{
    public class LoaiImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int maLoai;
            try
            {
                maLoai = int.Parse(value.ToString());
                switch (maLoai)
                {
                    case 1: return new BitmapImage(new Uri("listening.png"));
                    case 2: return new BitmapImage(new Uri("speaking.png"));
                    case 3: return new BitmapImage(new Uri("reading.png"));
                    default:
                        return new BitmapImage(new Uri("writing.png"));
                }
            }
            catch {
                return new BitmapImage(new Uri("listening.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
