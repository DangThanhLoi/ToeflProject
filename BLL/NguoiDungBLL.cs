using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class NguoiDungBLL
    {
        private ToeflDataContext _context;
        public NguoiDungBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public IEnumerable<NguoiDung> LayTatCa() {
            return _context.NguoiDungs.ToList<NguoiDung>();
        }
        public void Them(NguoiDung nd) {
            _context.NguoiDungs.InsertOnSubmit(nd);
        }
        public void Xoa(NguoiDung nd) {
            _context.NguoiDungs.DeleteOnSubmit(nd);
        }
        public void Xoa(IList<NguoiDung> nds) {
            _context.NguoiDungs.DeleteAllOnSubmit(nds);
        }
    }
}
