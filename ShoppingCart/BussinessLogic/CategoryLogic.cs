using BussinessLogic.Classes;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public static class CategoryLogic
    {
        public static Categoria GetCategoria(int id)
        {
            try
            {
                Category category = CategoryData.GetByID(id);
                Categoria categoria = Mapping(category);
                return categoria;
            }
            catch (NullReferenceException)
            {
                return null;
            }
                                                
                
        }
        public static List<Categoria> GetCategorias()
        {
                List<Category> categoryList = CategoryData.GetAll();
                List<Categoria> listaCategorias = new List<Categoria>();
                try
                {
                    foreach (Category category in categoryList)
                    {
                        Categoria categoria = Mapping(category);
                        listaCategorias.Add(categoria);
                    }
                    return listaCategorias;
                }
                catch (NullReferenceException)
                {
                    return null;
                }
        }

        private static Categoria Mapping(Category category)
        {
            Categoria categoria = new Categoria();
            categoria.CategoryID = category.CategoryID;
            categoria.CategoryName = category.CategoryName;
            return categoria;
        }
    }
}
