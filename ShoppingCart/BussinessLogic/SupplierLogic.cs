﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class SupplierLogic
    {
        public static string GetSupplierName(int id)
        {
            return SupplierData.GetSupplierNameByID(id);
        }
    }
}
