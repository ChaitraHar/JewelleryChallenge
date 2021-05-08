using JewelleryShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryShopTest.CommonHelper
{
    public static class CommonHelper
    {
        public static AppDbContext GetExchangerDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;
            var exchanger402Context = new AppDbContext(options);
            return exchanger402Context;
        }

        public static List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer{CustomerId=1, FirstName="John", LastName="Doe", isPrivilaged=true, Password="pwd1"},
                new Customer{CustomerId=2, FirstName="Jane", LastName="Doe", isPrivilaged=true, Password="pwd2"}
            };
        }
    }
}
