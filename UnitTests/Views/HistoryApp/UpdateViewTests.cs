using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryApp
{
    [TestClass]
    public class HistoryAppViewTest
    {
        [TestMethod]
        public void HistoryApp_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryAppController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
