using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionApp
{
    [TestClass]
    public class VersionAppCreateViewTests
    {
        [TestMethod]
        public void VersionApp_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionAppController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
