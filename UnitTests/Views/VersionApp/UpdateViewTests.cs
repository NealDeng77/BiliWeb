using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.VersionApp
{
    [TestClass]
    public class VersionAppViewTest
    {
        [TestMethod]
        public void VersionApp_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new VersionAppController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
