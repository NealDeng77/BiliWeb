using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class PhoneSettingsModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneSettingsModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new PhoneModel
            {
                ClinicID = "Clinic"
            };

            // Act
            var myNewData = new PhoneSettingsModel(myData);

            // Assert
            Assert.AreEqual("Clinic", myNewData.PhoneModel.ClinicID);
        
        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Get_Should_Pass()
        {
            // Arrange
            var myData = new PhoneSettingsModel();

            // Act

            // Assert
            Assert.IsNotNull(myData.UserList);
            Assert.IsNotNull(myData.PhoneModel);

            // TODO:  Add an Assert for each attribute

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void PhoneSettings_Set_Should_Pass()
        {
            // Arrange
            var myData = new PhoneSettingsModel();
            
            // Act
            myData.PhoneModel.ClinicID = "Clinic";
            myData.PhoneModel.DeviceModel = "Device";
            myData.PhoneModel.SerialNumber = "Serial";
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("Clinic", myData.PhoneModel.ClinicID);
            Assert.AreEqual("Device", myData.PhoneModel.DeviceModel);
            Assert.AreEqual("Serial", myData.PhoneModel.SerialNumber);

            // TODO:  Add an Assert for each attribute
        }
    }
}
