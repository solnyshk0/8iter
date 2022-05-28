using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.Dto;

namespace MyDB.BuisenessLayer
{
    public interface IProductProcess
    {
        ProductsDto Get(int CustomerID);
        ProductsDto Get(string Name);
        void Add(ProductsDto products);
        void Update(ProductsDto products);
        void Delete(int ProductID);

        IList<ProductsDto> GetList();
    }
}
