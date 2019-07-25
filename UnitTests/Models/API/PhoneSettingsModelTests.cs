using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using System.Collections.Generic;

namespace UnitTests.Models.API
{
    [TestClass]
    public class PhoneSettingsModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void PhoneSettings_InValid_Empty_Phone_Should_Fail()
        {
            // Arrange
            var data = new PhoneModel();

            // Act
            var result = new PhoneSettingsModel(data);

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Set test for PhoneSettings Model
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Set_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneSettingsModel
            {
                Status = 10,
                Message = "Message",
                PhoneModel = new PhoneModel(),
                UserList = new List<TechnicianModel>()
            };

            // Assert
            Assert.AreEqual(10, result.Status);
            Assert.AreEqual("Message", result.Message);
            Assert.IsNotNull(result.PhoneModel);
            Assert.IsNotNull(result.UserList);
        }

        /// <summary>
        /// Set test for PhoneSettings Model
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Get_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneSettingsModel
            {
                Status = 10,
                Message = "Message",
                PhoneModel = new PhoneModel(),
                UserList = new List<TechnicianModel>()
            };

            var Status = result.Status;
            var Message = result.Message;
            var PhoneModel = result.PhoneModel;
            var UserList = result.UserList;

            // Assert
            Assert.AreEqual(10, Status);
            Assert.AreEqual("Message", Message);
            Assert.IsNotNull(PhoneModel);
            Assert.IsNotNull(UserList);
        }

    }
}
