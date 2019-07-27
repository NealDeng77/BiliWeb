using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class HistoryOSModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void HistoryOS_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HistoryOSModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void HistoryOS_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new HistoryOSModel
            {
                PhoneID = "New"
            };

            // Act
            var myNewData = new HistoryOSModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.PhoneID);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void HistoryOS_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new HistoryOSModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void HistoryOS_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new HistoryOSModel();
            var myDataNew = new HistoryOSModel
            {
                PhoneID = "NewPhone",
                VersionOSID = "NewVersion",
                // TODO:  Add your atttrbutes here

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual("NewPhone", myData.PhoneID);
            Assert.AreEqual("NewVersion", myData.VersionOSID);
            // TODO:  Add an Assert for each attribute that should change

            
            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // TODO:  Add an Assert for each attribute that thould Not change

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void HistoryOS_Get_Should_Pass()
        {
            // Arrange
            var myData = new HistoryOSModel();

            // Act

            // Assert
            Assert.IsNull(myData.PhoneID);
            Assert.IsNull(myData.VersionOSID);
            // TODO:  Add an Assert for each attribute

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void HistoryOS_Set_Should_Pass()
        {
            // Arrange
            var myData = new HistoryOSModel();

            // Act
            myData.PhoneID = "NewPhone";
            myData.VersionOSID = "NewVersion";
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("NewPhone", myData.PhoneID);
            Assert.AreEqual("NewVersion", myData.VersionOSID);

            // TODO:  Add an Assert for each attribute
        }
    }
}
