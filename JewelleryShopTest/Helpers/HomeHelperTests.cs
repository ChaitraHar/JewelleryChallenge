using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelleryShop.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace JewelleryShop.Tests
{
    [TestClass()]
    public class HomeHelperTests
    { 
        [TestMethod]
        public void WriteToFileTest()
        {
            string folderPath = "C:\\TestJewelry\\";
            string filePath = folderPath + "Estimate.txt";
            var homeHelper = new HomeHelper();
            var result = homeHelper.WriteToFile(filePath, folderPath, "test content");
            Assert.IsNotNull(result);
        }
    }
}