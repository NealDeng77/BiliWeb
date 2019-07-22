using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultLog
{
    [TestClass]
    public class ResultLogIndexViewTest
    {
        [TestMethod]
        public void ResultLog_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
