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
            var myTest = new ResultLogModel();

            // Assert
            Assert.IsNotNull(myTest);
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
                Name = "New"
            };

            // Act
            var myNewData = new ResultLogModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.Name);
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
                Name = "New",
                BilirubinValue = 2,
                ClinicID = "Clinic",
                PhoneID = "Phone",
                UserID = "User",
                PhotoID = "Photo",
                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);

            // Assert
            Assert.AreEqual("New", myData.Name);
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
            Assert.IsNull(myData.Name);
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
            myData.Name = "New";

            // Assert
            Assert.AreEqual("New", myData.Name);
        }
    }
}
