using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.DataAccess.Entities;
using System.Data.SqlClient;

namespace MyDB.DataAccess
{
    class CustomersDao : BaseDao, ICustomersDao
    {
        private static Customers CreateCustomers(SqlDataReader reader)
        {
            Customers customers = new Customers();

            customers.CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID"));
            customers.Phone = reader.GetInt32(reader.GetOrdinal("Phone"));
            customers.ContactPerson = reader.GetString(reader.GetOrdinal("ContactPerson"));
            customers.Address = reader.GetString(reader.GetOrdinal("Address"));

            return customers;
        }
        public Customers Get(int CustomerID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select CustomerID, Phone, ContactPerson, Address from Customers where CustomerID = @CustomerID";
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    using (var DataReader = cmd.ExecuteReader())
                    {
                        if (DataReader.Read())
                        {
                            return CreateCustomers(DataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(Customers customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Customers (Phone, ContactPerson,Address) values (@Phone, @ContactPerson, @Address)";
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@ContactPerson", customer.ContactPerson);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Customers customer)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Customers set Phone=@Phone, ContactPerson=@ContactPerson, Address=@Address where CustomerID=@CustomerID";
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@ContactPerson", customer.ContactPerson);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int CustomerID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete from Customers where CustomerID=@CustomerID";
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Customers> GetList()
        {
            IList<Customers> customers = new List<Customers>();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select CustomerID, Phone, ContactPerson, Address from Customers";

                    using (var DataReader = cmd.ExecuteReader())
                    {
                        while(DataReader.Read())
                        {
                            customers.Add(CreateCustomers(DataReader));
                        }
                    }
                }
            }
            return customers;
        }
    }
}
