using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultLog
{
    [TestClass]
    public class ResultLogCreateViewTests
    {
        [TestMethod]
        public void ResultLog_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
