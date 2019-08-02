using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class ResultLogModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ResultLogModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void ResultLog_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new ResultLogModel
            {
                ClinicID = "New"
            };

            // Act
            var myNewData = new ResultLogModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.ClinicID);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new ResultLogModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new ResultLogModel();
            var myDataNew = new ResultLogModel
            {
                ID = myData.ID,
                BilirubinValue = 2,
                ClinicID = "New",
                PhoneID = "Phone",
                UserID = "User",
                PhotoID = "Photo",
                ParentReadingID = "Parent",
                ReadingSequence = 5,
            };

            // Act
            myData.Update(myDataNew);

            // Assert
            Assert.AreEqual(2, myData.BilirubinValue);
            Assert.AreEqual("New", myData.ClinicID);
            Assert.AreEqual("Phone", myData.PhoneID);
            Assert.AreEqual("User", myData.UserID);
            Assert.AreEqual("Photo", myData.PhotoID);
            Assert.AreEqual("Parent", myData.ParentReadingID);
            Assert.AreEqual(5, myData.ReadingSequence);
        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void ResultLog_Get_Should_Pass()
        {
            // Arrange
            var myData = new ResultLogModel();

            // Act

            // Assert
            Assert.IsNull(myData.ClinicID);
        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void ResultLog_Set_Should_Pass()
        {
            // Arrange
            var myData = new ResultLogModel();

            // Act
            myData.BilirubinValue = 2;
            myData.ClinicID = "New";
            myData.PhoneID = "Phone";
            myData.UserID = "User";
            myData.PhotoID = "Photo";
            myData.ParentReadingID = "Parent";
            myData.ReadingSequence = 5;

            // Assert
            Assert.AreEqual(2, myData.BilirubinValue);
            Assert.AreEqual("New", myData.ClinicID);
            Assert.AreEqual("Phone", myData.PhoneID);
            Assert.AreEqual("User", myData.UserID);
            Assert.AreEqual("Photo", myData.PhotoID);
            Assert.AreEqual("Parent", myData.ParentReadingID);
            Assert.AreEqual(5, myData.ReadingSequence);
        }
    }
}
