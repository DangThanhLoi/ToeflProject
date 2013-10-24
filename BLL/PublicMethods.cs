using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class PublicMethods
    {
        static ToeflDataContext context = new ToeflDataContext();
        public static ToeflDataContext GetDefaultInstance() {
            return context;
        }
        public static void SaveChange() {
            context.SubmitChanges();
        }
    }
}
