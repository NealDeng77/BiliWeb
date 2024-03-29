using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class VersionOSModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new VersionOSModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new VersionOSModel
            {
                VersionOSName = "New"
            };

            // Act
            var myNewData = new VersionOSModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.VersionOSName);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new VersionOSModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new VersionOSModel();
            var myDataNew = new VersionOSModel
            {
                VersionOSName = "New",

                // TODO:  Add your atttrbutes here

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual("New", myData.VersionOSName);
            // TODO:  Add an Assert for each attribute that should change

            
            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // TODO:  Add an Assert for each attribute that thould Not change

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Get_Should_Pass()
        {
            // Arrange
            var myData = new VersionOSModel();

            // Act

            // Assert
            Assert.IsNull(myData.VersionOSName);

            // TODO:  Add an Assert for each attribute

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void VersionOSModel_Set_Should_Pass()
        {
            // Arrange
            var myData = new VersionOSModel();

            // Act
            myData.VersionOSName = "New";
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("New", myData.VersionOSName);

            // TODO:  Add an Assert for each attribute
        }
    }
}
