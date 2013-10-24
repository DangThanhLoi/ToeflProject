using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class QuyenBLL
    {
        private ToeflDataContext _context;
        public QuyenBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public IEnumerable<Quyen> LayTatCa() {
            return _context.Quyens.ToList<Quyen>();
        }
    }
}
