using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Photo
{
    [TestClass]
    public class PhotoDeleteViewTest
    {
        [TestMethod]
        public void Photo_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new PhotoController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
