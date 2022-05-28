using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDB.DataAccess.Entities;
using MyDB.Dto;

namespace MyDB.BuisenessLayer
{
    public class DtoConverter
    {
        #region Products
        public static Products Convert(ProductsDto productsDto)
        {
            if (productsDto == null)
            {
                return null;
            }
            Products products = new Products();
            products.ProductID = productsDto.ProductID;
            products.Name = productsDto.Name;
            products.WholesalePrice = productsDto.WholesalePrice;
            products.RetailPrice = productsDto.RetailPrice;
            products.Description = productsDto.Description;
            products.Cost = productsDto.Cost;
            return products;
        }

        public static ProductsDto Convert(Products products)
        {
            if (products == null)
            {
                return null;
            }
            ProductsDto productsDto = new ProductsDto();
            productsDto.ProductID = products.ProductID;
            productsDto.Name = products.Name;
            productsDto.WholesalePrice = products.WholesalePrice;
            productsDto.RetailPrice = products.RetailPrice;
            productsDto.Description = products.Description;
            productsDto.Cost = products.Cost;
            return productsDto;
        }

        public static IList<ProductsDto> Convert(IList<Products> products)
        {
            if (products == null)
            {
                return null;
            }
            IList<ProductsDto> productsDto = new List<ProductsDto>();
            foreach (var item in products)
            {
                productsDto.Add(Convert(item));
            }
            return productsDto;
        }
        #endregion
        #region Customers
        public static Customers Convert(CustomersDto customersDto)
        {
            if(customersDto == null)
            {
                return null;
            }
            Customers customers = new Customers();
            customers.CustomerID = customersDto.CustomerID;
            customers.Address = customersDto.Address;
            customers.ContactPerson = customersDto.ContactPerson;
            customers.Phone = customersDto.Phone;
            return customers;
        }

        public static CustomersDto Convert(Customers customers)
        {
            if(customers == null)
            {
                return null;
            }
            CustomersDto customersDto = new CustomersDto();
            customersDto.CustomerID = customers.CustomerID;
            customersDto.Address = customers.Address;
            customersDto.ContactPerson = customers.ContactPerson;
            customersDto.Phone = customers.Phone;
            return customersDto;
        }

        public static IList<CustomersDto> Convert(IList<Customers> customers)
        {
            if(customers == null)
            {
                return null;
            }
            IList<CustomersDto> customersDto = new List<CustomersDto>();
            foreach(var item in customers)
                    {
                customersDto.Add(Convert(item));
            }
            return customersDto;
        }
        #endregion
    }
}
