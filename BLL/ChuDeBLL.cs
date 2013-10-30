using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ChuDeBLL
    {
        private ToeflDataContext _context;
        public ChuDeBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public List<ChuDe> LayChuDe() {
            return _context.ChuDes.ToList();
        }
        public List<ChuDe> LayChuDe(PhanThi pt) {
            return pt.ChuDes.ToList();
        }
        public List<ChuDe> LayChuDe(List<PhanThi> pts) {
            List<ChuDe> newList = new List<ChuDe>();
            foreach (PhanThi item in pts)
            {
                newList.AddRange(item.ChuDes.ToList());
            }
            return newList;
        }
    }
}
