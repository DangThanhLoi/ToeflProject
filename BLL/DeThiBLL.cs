using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class DeThiBLL
    {
        private ToeflDataContext _context;
        public DeThiBLL() {
            _context = PublicMethods.GetDefaultInstance();
        }
        public List<DeThi> LayTatCa() {
            return _context.DeThis.ToList();
        }
    }
}
