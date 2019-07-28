using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryApp
{
    [TestClass]
    public class HistoryAppIndexViewTest
    {
        [TestMethod]
        public void HistoryApp_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryAppController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
