using BussinessLogic.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary
{
    [ServiceContract]
    interface ICategoryService
    {
        [OperationContract]
        List<Categoria> GetCategoryList();
    }
}
