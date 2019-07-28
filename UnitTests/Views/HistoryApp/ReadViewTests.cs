using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.HistoryApp
{
    [TestClass]
    public class HistoryAppReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void HistoryApp_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new HistoryAppController();

            // Act
            var result = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
