using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryOS
{
    [TestClass]
    public class HistoryOSDeleteViewTest
    {
        [TestMethod]
        public void HistoryOS_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new HistoryOSController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
