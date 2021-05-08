using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelleryShop.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using JewelleryShop.Models;
using JewelleryShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using JewelleryShopTest.CommonHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace JewelleryShop.Tests
{
    [TestClass()]
    public class LoginControllerTests
    {
        private readonly Mock<ICustomerRepository> customer;
        private readonly Mock<IHomeHelper> homeHelper;
        
        public LoginControllerTests()
        {
            this.customer = new Mock<ICustomerRepository>();
            this.homeHelper = new Mock<IHomeHelper>();
        }       
    }
}