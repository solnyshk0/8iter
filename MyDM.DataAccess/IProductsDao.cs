using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.DataAccess.Entities;

namespace MyDB.DataAccess
{
    public interface IProductsDao
    {
        Products Get(int CustomerID);
         Products Get(string Name);
         void Add(Products product);
         void Update(Products product);
         void Delete(int ProductID);

         IList<Products> GetList();
    }
}
