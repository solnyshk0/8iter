using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.DataAccess.Entities;

namespace MyDB.DataAccess
{
    public interface ICustomersDao
    {
        Customers Get(int CustomerID);
        void Add(Customers customer);
        void Update(Customers customer);
        void Delete(int CustomerID);

        IList<Customers> GetList();
    }
}
