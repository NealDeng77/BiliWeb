using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class PhoneModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Phone_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void Phone_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new PhoneModel
            {
                ClinicID = "Clinic",
                DeviceModel = "Device",
                SerialNumber = "Serial",
                TimeOut = 1,
                ReadingCaptureCount = 1,
                TransmitSuccessImage = true,
                TransmitFailImage = true
            };

            // Act
            var myNewData = new PhoneModel(myData);

            // Assert
            Assert.AreEqual("Clinic", myNewData.ClinicID);
            Assert.AreEqual("Device", myNewData.DeviceModel);
            Assert.AreEqual("Serial", myNewData.SerialNumber);
            Assert.AreEqual(1, myNewData.TimeOut);
            Assert.AreEqual(1, myNewData.ReadingCaptureCount);
            Assert.AreEqual(true, myNewData.TransmitSuccessImage);
            Assert.AreEqual(true, myNewData.TransmitFailImage);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Phone_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new PhoneModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Phone_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new PhoneModel();
            var myDataNew = new PhoneModel
            {
                ClinicID = "Clinic",
                DeviceModel = "Device",
                SerialNumber = "Serial",
                TimeOut = 1,
                ReadingCaptureCount = 1,
                TransmitFailImage = true,
                TransmitSuccessImage = true,

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual("Clinic", myData.ClinicID);
            Assert.AreEqual("Device", myData.DeviceModel);
            Assert.AreEqual("Serial", myData.SerialNumber);
            Assert.AreEqual(1, myData.TimeOut);
            Assert.AreEqual(1, myData.ReadingCaptureCount);
            Assert.AreEqual(true, myData.TransmitSuccessImage);
            Assert.AreEqual(true, myData.TransmitFailImage);

            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // TODO:  Add an Assert for each attribute that thould Not change
        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void Phone_Get_Should_Pass()
        {
            // Arrange
            var myData = new PhoneModel();

            // Act

            // Assert
            Assert.IsNull(myData.ClinicID);
            Assert.IsNull(myData.DeviceModel);
            Assert.IsNull(myData.SerialNumber);
            Assert.AreEqual(10000,myData.TimeOut);
            Assert.AreEqual(1, myData.ReadingCaptureCount);
            Assert.AreEqual(false, myData.TransmitSuccessImage);
            Assert.AreEqual(false, myData.TransmitFailImage);

            // TODO:  Add an Assert for each attribute

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void Phone_Set_Should_Pass()
        {
            // Arrange
            var myData = new PhoneModel();

            // Act
            myData.ClinicID = "Clinic";
            myData.DeviceModel = "Device";
            myData.SerialNumber = "Serial";
            myData.TimeOut = 1;
            myData.ReadingCaptureCount = 1;
            myData.TransmitSuccessImage = true;
            myData.TransmitFailImage = true;
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("Clinic", myData.ClinicID);
            Assert.AreEqual("Device", myData.DeviceModel);
            Assert.AreEqual("Serial", myData.SerialNumber);
            Assert.AreEqual(1, myData.TimeOut);
            Assert.AreEqual(1, myData.ReadingCaptureCount);
            Assert.AreEqual(true, myData.TransmitSuccessImage);
            Assert.AreEqual(true, myData.TransmitFailImage);

            // TODO:  Add an Assert for each attribute
        }
    }
}
