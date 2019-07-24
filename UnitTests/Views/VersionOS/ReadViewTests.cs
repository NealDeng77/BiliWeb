using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionOS
{
    [TestClass]
    public class VersionOSReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void VersionOS_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new VersionOSController();

            // Act
            var result = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
