using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using BiliWeb.Backend;
using System.Collections.Generic;

namespace UnitTests.Controllers.API
{
    [TestClass]
    public class PhoneSettingsControlerTests
    {
        #region GetTests

        /// <summary>
        /// Ensure the Get Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneSettingsController();

            // Act
            var result = myController.Get();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        
        #endregion GetTests

    }
}
