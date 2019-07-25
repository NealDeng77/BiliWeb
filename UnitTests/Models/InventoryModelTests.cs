using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class InventoryModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Inventory_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new InventoryModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void Inventory_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new InventoryModel
            {
                ClinicID = "Clinic",
                TestStripStock = 50
            };
        

            // Act
            var myNewData = new InventoryModel(myData);

            // Assert clinic 
            Assert.AreEqual("Clinic", myNewData.ClinicID);

            //Assert test strip count
            Assert.AreEqual(50, myNewData.TestStripStock);

        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Inventory_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new InventoryModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Inventory_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new InventoryModel();
            var myDataNew = new InventoryModel
            {
                //Clinic 
                ClinicID = "Clinic",

                //Count of test strips
                TestStripStock = 50,

                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            // Clinic and test strip count attribute should change
            Assert.AreEqual("Clinic", myData.ClinicID);
            Assert.AreEqual(50, myData.TestStripStock);

            Assert.AreNotEqual(myData.Date, myDataNew.Date);

        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void Inventory_Get_Should_Pass()
        {
            // Arrange
            var myData = new InventoryModel();

            // Act

            // Assert
            Assert.IsNull(myData.ClinicID);
            Assert.AreEqual(0, myData.TestStripStock);

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void Inventory_Set_Should_Pass()
        {
            // Arrange
            var myData = new InventoryModel();

            // Act
            myData.ClinicID = "Clinic";
            myData.TestStripStock = 12;

            // Assert
            Assert.AreEqual("Clinic", myData.ClinicID);
            Assert.AreEqual(12, myData.TestStripStock);

        }
    }
}