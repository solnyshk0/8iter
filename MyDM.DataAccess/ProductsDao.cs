using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.DataAccess.Entities;
using System.Data.SqlClient;

namespace MyDB.DataAccess
{
    class ProductsDao : BaseDao, IProductsDao
    {
        private static Products CreateProduct(SqlDataReader reader)
        {
            Products product = new Products();

            product.ProductID = reader.GetInt32(reader.GetOrdinal("ProductID"));
            product.Name = reader.GetString(reader.GetOrdinal("Name"));
            product.WholesalePrice = reader.GetInt32(reader.GetOrdinal("WholesalePrice"));
            product.RetailPrice = reader.GetInt32(reader.GetOrdinal("RetailPrice"));

            object description = reader["Description"];
            if (description != DBNull.Value)
            {
                product.Description = Convert.ToString(description);
            }

            object cost = reader["Cost"];
            if (cost != DBNull.Value)
            {
                product.Cost = Convert.ToInt32(cost);
            }

            return product;
        }
        public Products Get(int ProductID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select ProductID, Name, WholesalePrice, RetailPrice, Cost, Description from Products where ProductID = @ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    using (var DataReader = cmd.ExecuteReader())
                    {
                        if (DataReader.Read())
                        {
                            return CreateProduct(DataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public Products Get(string Name)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select ProductID, Name, WholesalePrice, RetailPrice, Cost, Description from Products where Name = @Name";
                    cmd.Parameters.AddWithValue("@ProduNamectID", Name);
                    using (var DataReader = cmd.ExecuteReader())
                    {
                        if (DataReader.Read())
                        {
                            return CreateProduct(DataReader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public void Add(Products product)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "insert into Products (Name, WholesalePrice, RetailPrice, Description, Cost) values (@Name, @WholesalePrice, @RetailPrice, @Description, @Cost)";
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@WholesalePrice", product.WholesalePrice);
                    cmd.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);

                    object description;
                    if (product.Description != null)
                    {
                        description = product.Description;
                    }
                    else
                    {
                        description = DBNull.Value;
                    }
                    cmd.Parameters.AddWithValue("@Description", description);

                    object cost;
                    if (product.Cost.HasValue)
                    {
                        cost = product.Cost.Value;
                    }
                    else
                    {
                        cost = DBNull.Value;
                    }
                    cmd.Parameters.AddWithValue("@Cost", cost);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Products product)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "update Products set Name=@Name, WholesalePrice=@WholesalePrice, RetailPrice=@RetailPrice, Description=@Description, Cost=@Cost where ProductID=@ProductID";
                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@WholesalePrice", product.WholesalePrice);
                    cmd.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);

                    object description;
                    if (product.Description != null)
                    {
                        description = product.Description;
                    }
                    else
                    {
                        description = DBNull.Value;
                    }
                    cmd.Parameters.AddWithValue("@Description", description);

                    object cost;
                    if (product.Cost.HasValue)
                    {
                        cost = product.Cost.Value;
                    }
                    else
                    {
                        cost = DBNull.Value;
                    }
                    cmd.Parameters.AddWithValue("@Cost", cost);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Delete(int ProductID)
        {
            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "delete from Products where ProductID=@ProductID";
                    cmd.Parameters.AddWithValue("@ProductID", ProductID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Products> GetList()
        {
            IList<Products> products = new List<Products>();

            using (var conn = GetConnection())
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select Name, WholesalePrice, RetailPrice, Description, Cost from Products";

                    using (var DataReader = cmd.ExecuteReader())
                    {
                        while (DataReader.Read())
                        {
                            products.Add(CreateProduct(DataReader));
                        }
                    }
                }
            }
            return products;
        }
    }
}
