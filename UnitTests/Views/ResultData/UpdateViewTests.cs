using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultData
{
    [TestClass]
    public class ResultDataViewTest
    {
        [TestMethod]
        public void ResultData_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultDataController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
