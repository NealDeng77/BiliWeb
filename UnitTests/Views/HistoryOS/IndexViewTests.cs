using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryOS
{
    [TestClass]
    public class HistoryOSIndexViewTest
    {
        [TestMethod]
        public void HistoryOS_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryOSController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
