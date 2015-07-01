using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using BussinessLogic;

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
                catch (EntityException entityExcp)
                {
                    Logger.Write(entityExcp);
                    return null;
                }
            }
        }

        static public Category GetByID(int id)
        {
            using (NorthWindEntities context= new NorthWindEntities())
            {
                try
                {
                    return context.Categories.Where(x => x.CategoryID == id).FirstOrDefault();
                }
                catch (EntityException entityExcp)
                {
                    Logger.Write(entityExcp);
                    return null;
                }

            }
        }
    }
}
