using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultLog
{
    [TestClass]
    public class ResultLogDeleteViewTest
    {
        [TestMethod]
        public void ResultLog_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
