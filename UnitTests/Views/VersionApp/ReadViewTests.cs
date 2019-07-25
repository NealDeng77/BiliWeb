using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionApp
{
    [TestClass]
    public class VersionAppReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void VersionApp_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new VersionAppController();

            // Act
            var result = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
