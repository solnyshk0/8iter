using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.Dto;
using MyDB.DataAccess;

namespace MyDB.BuisenessLayer
{
    public class CustomersProcess: ICustomersProcess
    {
        private readonly ICustomersDao customersDao;

        public CustomersProcess()
        {
            customersDao = DaoFactory.GetCustomersDao();
        }

        public CustomersDto Get(int CustomerID)
        {
            return DtoConverter.Convert(customersDao.Get(CustomerID));
        }
        public void Add(CustomersDto customer)
        {
            customersDao.Add(DtoConverter.Convert(customer));

        }
        public void Update(CustomersDto customer)
        {
            customersDao.Update(DtoConverter.Convert(customer));
        }
        public void Delete(int CustomerID)
        {
            customersDao.Delete(CustomerID);
        }

        public IList<CustomersDto> GetList()
        {
            return DtoConverter.Convert(customersDao.GetList());
        }
    }
}
