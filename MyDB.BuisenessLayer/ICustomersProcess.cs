using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.Dto;

namespace MyDB.BuisenessLayer
{
    public interface ICustomersProcess
    {
        CustomersDto Get (int CustomerID);
        void Add(CustomersDto customer);
        void Update(CustomersDto customer);
        void Delete(int CustomerID);

        IList<CustomersDto> GetList();
    }
}
