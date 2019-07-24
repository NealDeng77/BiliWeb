using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultData
{
    [TestClass]
    public class ResultDataCreateViewTests
    {
        [TestMethod]
        public void ResultData_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultDataController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
