using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionApp
{
    [TestClass]
    public class VersionAppIndexViewTest
    {
        [TestMethod]
        public void VersionApp_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionAppController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
