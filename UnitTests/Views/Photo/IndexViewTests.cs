using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Photo
{
    [TestClass]
    public class PhotoIndexViewTest
    {
        [TestMethod]
        public void Photo_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhotoController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
