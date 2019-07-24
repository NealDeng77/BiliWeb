using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class PhotoModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Photo_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhotoModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void Photo_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new PhotoModel
            {
                Device = "Device",
                Status = (int)PhotoStatusEnum.Ok,
                Note = "Photo is great",
                Score = 1.1

            };

            // Act
            var myNewData = new PhotoModel(myData);

            // Assert
            Assert.AreEqual("Device", myNewData.Device);
            Assert.AreEqual(0, myNewData.Status);
            Assert.AreEqual("Photo is great", myNewData.Note);
            Assert.AreEqual(1.1, myNewData.Score);

        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Photo_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new PhotoModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Photo_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new PhotoModel
            {
                Device = "Device"
            };
            var myDataNew = new PhotoModel
            {
                Device = "Device",
                Status = (int)PhotoStatusEnum.Error,
                Note = "Photo is too blurry",
                Score = 20,

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);

            // Assert
            // Add an Assert for each attribute that should change
            Assert.AreEqual(1, myData.Status);
            Assert.AreEqual("Photo is too blurry", myData.Note);
            Assert.AreEqual(20, myData.Score);
            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // Add an Assert for each attribute that thould Not change
            Assert.AreEqual("Device", myData.Device);

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void Photo_Get_Should_Pass()
        {
            // Arrange
            var myData = new PhotoModel
            {
                Status = (int)PhotoStatusEnum.Ok,
                Score = 20
            };

            // Act
            var status = myData.Status;
            var score = myData.Score;
            // Assert
            Assert.IsNull(myData.Device);
            Assert.AreEqual(20, score);
            Assert.IsNull(myData.Note);
            Assert.AreEqual(0, status);
        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void Photo_Set_Should_Pass()
        {
            // Arrange
            var myData = new PhotoModel();

            // Act
            myData.Device = "Device";
            myData.Status = (int)PhotoStatusEnum.Ok;
            myData.Note = "Photo is great";
            myData.Score = 1.1;
            // Assert
            Assert.AreEqual("Device", myData.Device);
            Assert.AreEqual(0, myData.Status);
            Assert.AreEqual("Photo is great", myData.Note);
            Assert.AreEqual(1.1, myData.Score);
        }
    }
}
