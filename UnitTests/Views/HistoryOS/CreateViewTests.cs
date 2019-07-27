using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryOS
{
    [TestClass]
    public class HistoryOSCreateViewTests
    {
        [TestMethod]
        public void HistoryOS_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new HistoryOSController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
