using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultLog
{
    [TestClass]
    public class ResultLogUpdateViewTest
    {
        [TestMethod]
        public void ResultLog_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var myTest = myController.Update("abc");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
