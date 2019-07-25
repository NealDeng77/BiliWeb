using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Photo
{
    [TestClass]
    public class PhotoReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void Photo_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new PhotoController();

            // Act
            var result = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
