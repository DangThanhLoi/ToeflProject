using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class PhanThiBLL
    {
        public static int LISTENING = 1;
        public static int SPEAKING = 2;
        public static int READING = 3;
        public static int WRITING = 4;
        private ToeflDataContext _context;
        public PhanThiBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public List<PhanThi> LayPhanThi() {
            return _context.PhanThis.ToList();
        }
        public List<PhanThi> LayPhanThi(int maDe) {
            return _context.PhanThis.Where(pt => pt.MaDe.Equals(maDe)).ToList();
        }
        public PhanThi LayPhanThi(int maDe, int maLoai) {
            return this.LayPhanThi(maDe).Where(pt => pt.MaLoai.Equals(maLoai)).FirstOrDefault();
        }
        public PhanThi LayPhanThiTheoMa(int mapt) {
            return _context.PhanThis.Where(pt => pt.MaPT.Equals(mapt)).FirstOrDefault();
        }
    }
}
