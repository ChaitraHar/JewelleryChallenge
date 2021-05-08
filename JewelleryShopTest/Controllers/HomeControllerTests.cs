using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelleryShop.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using JewelleryShop.Models;
using Moq;
using Microsoft.EntityFrameworkCore;
using JewelleryShop.Helpers;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using JewelleryShopTest.CommonHelper;
using System.Web.Helpers;
using System.Diagnostics;

namespace JewelleryShop.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        private readonly Mock<ICustomerRepository> customer;
        private readonly Mock<IHomeHelper> homeHelper;
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<HttpContext> context;
        private readonly Mock<Activity> activity;
        private readonly IConfiguration config;

        public HomeControllerTests()
        {
            this.customer = new Mock<ICustomerRepository>();
            this.homeHelper = new Mock<IHomeHelper>();
            this.configuration = new Mock<IConfiguration>();
            this.context = new Mock<HttpContext>();
            this.activity = new Mock<Activity>();
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            config = builder.Build();
        }

        [TestMethod()]
        public void IndexTest()
        {
            //Arrange
            var dbContext = CommonHelper.GetExchangerDbContext("GetCustomers");
            dbContext.Customers.AddRange(CommonHelper.GetCustomers());
            customer.Setup(c => c.GetById(It.IsAny<int>())).Returns(CommonHelper.GetCustomers()[0]);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            tempData["custId"] = 1;
            HomeController homeController = new HomeController(homeHelper.Object, configuration.Object, customer.Object)
            {
                TempData = tempData
            };

            //Act
            var res = homeController.Index(true);

            //Assert
            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }

        [TestMethod]
        [DataRow(4000, 3000, true)]
        [DataRow(4000, 3000, false)]
        public void PrintToFileTest(double total, double discounted, bool isPrivilaged)
        {
            //Arrange
            homeHelper.Setup(c => c.WriteToFile(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            HomeController homeController = new HomeController(homeHelper.Object, configuration.Object, customer.Object);

            //Act
            homeController.PrintToFile(total, discounted, isPrivilaged);
            var fileRes = homeController.DownloadFile();

            //Assert
            Assert.IsInstanceOfType(fileRes, typeof(FileResult));
        }

        [TestMethod]
        [DataRow(4000, 3000, true)]
        [DataRow(4000, 3000, false)]
        public void PrintToScreenTest(double total, double discounted, bool isPrivilaged)
        {
            //Arrange
            HomeController homeController = new HomeController(homeHelper.Object, configuration.Object, customer.Object);

            //Act
            var fileRes = homeController.EstimatePopup(total, discounted, isPrivilaged);

            //Assert
            Assert.IsInstanceOfType(fileRes, typeof(PartialViewResult));
        }

        [TestMethod]
        [DataRow(4000, 3000, true)]
        [DataRow(4000, 3000, false)]
        [ExpectedException(typeof(NotImplementedException))]
        public void PrintToPaperTest(double total, double discounted, bool isPrivilaged)
        {
            //Arrange
            HomeController homeController = new HomeController(homeHelper.Object, configuration.Object, customer.Object);

            //Act
             homeController.PrintToPaper(total, discounted, isPrivilaged);
        }

        [TestMethod()]
        public void AuthenticateTest()
        {
            //Arrange
            var dbContext = CommonHelper.GetExchangerDbContext("LoginCustomer");
            dbContext.Customers.AddRange(CommonHelper.GetCustomers());
            customer.Setup(c => c.GetByUserName(It.IsAny<string>())).Returns(CommonHelper.GetCustomers()[0]);
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            HomeController homeController = new HomeController(homeHelper.Object, configuration.Object, customer.Object);
            

            //Act
            var res = homeController.Authenticate("John", "pwd1");

            //Assert
            Assert.IsInstanceOfType(res, typeof(JsonResult));
        }        
    }
}