using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class LoaiBLL
    {
        private ToeflDataContext _context;
        public LoaiBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public List<Loai> LayTatCa() {
            return _context.Loais.ToList();
        }
        public Loai GetLoaiTheoMa(int maLoai) {
            return _context.Loais.Where(l => l.MaLoai.Equals(maLoai)).FirstOrDefault();
        }
        public Loai GetFirst() {
            return _context.Loais.FirstOrDefault();
        }
    }
}
