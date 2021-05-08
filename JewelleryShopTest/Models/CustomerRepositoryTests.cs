using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelleryShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using JewelleryShopTest.CommonHelper;
using Moq;

namespace JewelleryShop.Tests
{
    [TestClass()]
    public class CustomerRepositoryTests
    {
        private Mock<AppDbContext> appDb;
        public CustomerRepositoryTests()
        {
            this.appDb = new Mock<AppDbContext>();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var dbContext = CommonHelper.GetExchangerDbContext("GetCustomersRepo");
            dbContext.Customers.AddRange(CommonHelper.GetCustomers());
            dbContext.SaveChanges();

            CustomerRepository customerRepository = new CustomerRepository(dbContext);

            var result = customerRepository.GetById(1);

            Assert.AreEqual("John", result.FirstName);
        }

        [TestMethod()]
        public void GetByUserNameTest()
        {
            var dbContext = CommonHelper.GetExchangerDbContext("GetCustomersRepos");
            dbContext.Customers.AddRange(CommonHelper.GetCustomers());
            dbContext.SaveChanges();

            CustomerRepository customerRepository = new CustomerRepository(dbContext);

            var result = customerRepository.GetByUserName("Jane");

            Assert.AreEqual(2, result.CustomerId);
        }
    }
}