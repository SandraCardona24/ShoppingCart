using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SupplierData
    {
        static public string GetSupplierNameByID(int id)
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {
                return context.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault().CompanyName;
            }
        }
    }
}
