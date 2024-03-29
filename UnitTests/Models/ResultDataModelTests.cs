using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class ResultDataModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void ResultData_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ResultDataModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void ResultData_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new ResultDataModel
            {
                LabResult = 123
            };

            // Act
            var myNewData = new ResultDataModel(myData);

            // Assert
            Assert.AreEqual(123, myNewData.LabResult);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void ResultData_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new ResultDataModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void ResultData_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new ResultDataModel();
            var myDataNew = new ResultDataModel
            {
                LabResult = 11,
                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual(11, myData.LabResult);

            // Data fields that should NOT match
            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            Assert.AreNotEqual(myData.ResultCode, myDataNew.ResultCode);    // Should not match

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void ResultData_Get_Should_Pass()
        {
            // Arrange
            var myData = new ResultDataModel();

            // Act

            // Assert
            Assert.AreEqual(0, myData.LabResult);
            Assert.AreNotEqual("000000", myData.ResultCode);
        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void ResultData_Set_Should_Pass()
        {
            // Arrange
            var myData = new ResultDataModel();

            // Act
            myData.LabResult = 12;
            myData.ResultCode = "123456";

            // Assert
            Assert.AreEqual(12, myData.LabResult);
            Assert.AreEqual("123456", myData.ResultCode);
        }
    }
}
