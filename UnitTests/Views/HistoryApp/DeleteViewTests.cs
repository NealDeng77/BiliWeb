using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryApp
{
    [TestClass]
    public class HistoryAppDeleteViewTest
    {
        [TestMethod]
        public void HistoryApp_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new HistoryAppController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
