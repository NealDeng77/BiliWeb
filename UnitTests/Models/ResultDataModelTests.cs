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
                Name = "New"
            };

            // Act
            var myNewData = new ResultDataModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.Name);
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
                Name = "New",
                LabResult = 11,

                // TODO:  Add your atttrbutes here

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual("New", myData.Name);
            Assert.AreEqual(11, myData.LabResult);

            // TODO:  Add an Assert for each attribute that should change


            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // TODO:  Add an Assert for each attribute that thould Not change

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
            Assert.IsNull(myData.Name);
            Assert.AreEqual(0, myData.LabResult);

            // TODO:  Add an Assert for each attribute

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
            myData.Name = "New";
            myData.LabResult = 12;
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("New", myData.Name);
            Assert.AreEqual(12, myData.LabResult);

            // TODO:  Add an Assert for each attribute
        }
    }
}
