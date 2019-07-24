using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultData
{
    [TestClass]
    public class ResultDataIndexViewTest
    {
        [TestMethod]
        public void ResultData_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultDataController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
