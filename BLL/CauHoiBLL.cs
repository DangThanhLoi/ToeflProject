using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class CauHoiBLL
    {
        private ToeflDataContext _context;
        public CauHoiBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public List<CauHoi> LayTatCa() {
            return _context.CauHois.ToList();
        }
        public void ThemCauHoi(CauHoi ch) {
            _context.CauHois.InsertOnSubmit(ch);
        }
        public void XoaCauHoi(CauHoi ch) {
            _context.CauHois.DeleteOnSubmit(ch);
        }
    }
}
