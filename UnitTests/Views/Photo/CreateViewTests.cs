using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Photo
{
    [TestClass]
    public class PhotoCreateViewTests
    {
        [TestMethod]
        public void Photo_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhotoController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
