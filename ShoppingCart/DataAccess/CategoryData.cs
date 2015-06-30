using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataAccess
{
    public class CategoryData
    {
        static public List<Category> GetAll()
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {
                try
                {
                       return context.Categories.ToList();
                }
                catch (EntityException)
                {
                    return null;
                }
            }
        }

        static public Category GetByID(int id)
        {
            using (NorthWindEntities context= new NorthWindEntities())
            {
                return context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
            }
        }
    }
}
