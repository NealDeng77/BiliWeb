using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionOS
{
    [TestClass]
    public class VersionOSDeleteViewTest
    {
        [TestMethod]
        public void VersionOS_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new VersionOSController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
