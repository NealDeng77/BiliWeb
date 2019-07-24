using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionOS
{
    [TestClass]
    public class VersionOSIndexViewTest
    {
        [TestMethod]
        public void VersionOS_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionOSController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
