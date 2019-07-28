using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryApp
{
    [TestClass]
    public class HistoryAppCreateViewTests
    {
        [TestMethod]
        public void HistoryApp_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryAppController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
