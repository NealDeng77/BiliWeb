using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionOS
{
    [TestClass]
    public class VersionOSViewTest
    {
        [TestMethod]
        public void VersionOS_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionOSController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
