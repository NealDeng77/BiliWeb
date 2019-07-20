using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UnitTests.Controllers
{
    [TestClass]
    public class PhoneResultLogControlerTests
    {
        #region PostTests

        /// <summary>
        /// Ensure the Post Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Post_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            // Act
            var result = myController.Post(null);

            // Reset

            // Assert
            Assert.AreEqual("Error",result);
        }

        //[TestMethod]
        //public void ResultLog_Post_Post_Invalid_Model_Should_Send_Back_For_Edit()
        //{
        //    // Arrange
        //    var controller = new PhoneResultLogController();
        //    var data = new ResultLogModel();

        //    // Make ModelState Invalid
        //    controller.ModelState.AddModelError("test", "test");

        //    // Act
        //    var result = controller.Post(data) as RedirectToActionResult;

        //    // Assert
        //    Assert.AreEqual("Error", result.ActionName);
        //}

        /// <summary>
        /// Ensure the Post Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Post_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneResultLogController();
            var myData = new ResultLogModel();

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual("OK",result);
        }
        #endregion PostTests

    }
}
