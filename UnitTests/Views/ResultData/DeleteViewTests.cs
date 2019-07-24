using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultData
{
    [TestClass]
    public class ResultDataDeleteViewTest
    {
        [TestMethod]
        public void ResultData_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ResultDataController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
