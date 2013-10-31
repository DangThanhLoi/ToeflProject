using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using BLL;
using DAL;
namespace ToeflProject
{
    public class LoaiConverter : IValueConverter
    {
        LoaiBLL lBll = new LoaiBLL();
        PhanThiBLL ptBll = new PhanThiBLL();
        int made;
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int mapt;
            try
            {
                mapt = int.Parse(value.ToString());
                PhanThi pt = ptBll.LayPhanThiTheoMa(mapt);
                this.made = pt.MaDe;
                Loai l = lBll.GetLoaiTheoMa(pt.MaLoai);
                return l.MaLoai;
            }
            catch {
                int ml = lBll.GetFirst().MaLoai;
                return ml;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int maloai = int.Parse(value.ToString());
            PhanThi pt = ptBll.LayPhanThi(made, maloai);
            return pt.MaPT;
        }
    }
}
