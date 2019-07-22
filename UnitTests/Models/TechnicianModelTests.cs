using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class TechnicianModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Technician_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new TechnicianModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void Technician_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new TechnicianModel
            {
                Name = "New"
            };

            // Act
            var myNewData = new TechnicianModel(myData);

            // Assert
            Assert.AreEqual("New", myNewData.Name);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Technician_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new TechnicianModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Technician_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new TechnicianModel();
            var myDataNew = new TechnicianModel
            {
                Name = "New",

                // TODO:  Add your atttrbutes here

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);

            // Assert
            Assert.AreEqual("New", myData.Name);
            // TODO:  Add an Assert for each attribute that should change

            
            Assert.AreNotEqual(myData.Date, myDataNew.Date);
            // TODO:  Add an Assert for each attribute that thould Not change

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void Technician_Get_Should_Pass()
        {
            // Arrange
            var myData = new TechnicianModel();

            // Act

            // Assert
            Assert.IsNull(myData.Name);

            // TODO:  Add an Assert for each attribute

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void Technician_Set_Should_Pass()
        {
            // Arrange
            var myData = new TechnicianModel();

            // Act
            myData.Name = "New";
            // TODO:  Add each attribute here

            // Assert
            Assert.AreEqual("New", myData.Name);

            // TODO:  Add an Assert for each attribute
        }
    }
}
