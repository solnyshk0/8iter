using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.Dto;
using MyDB.DataAccess;

namespace MyDB.BuisenessLayer
{
    public class ProductProcess : IProductProcess
    {
        private readonly IProductsDao productDao;

        public ProductProcess()
        {
            productDao = DaoFactory.GetProductsDao();
        }

        public ProductsDto Get(int ProductID)
        {
            return DtoConverter.Convert(productDao.Get(ProductID));
        }
        public ProductsDto Get(string Name)
        {
            return DtoConverter.Convert(productDao.Get(Name));

        }
        public void Add(ProductsDto products)
        {
            productDao.Add(DtoConverter.Convert(products));
        }
        public void Update(ProductsDto products)
        {
            productDao.Update(DtoConverter.Convert(products));

        }
        public void Delete(int ProductID)
        {
            productDao.Delete(ProductID);
        }

        public IList<ProductsDto> GetList()
        {
            return DtoConverter.Convert(productDao.GetList());
        }
    }
}
