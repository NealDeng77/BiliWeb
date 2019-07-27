using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryOS
{
    [TestClass]
    public class HistoryOSViewTest
    {
        [TestMethod]
        public void HistoryOS_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryOSController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
