using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Photo
{
    [TestClass]
    public class PhotoViewTest
    {
        [TestMethod]
        public void Photo_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhotoController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
