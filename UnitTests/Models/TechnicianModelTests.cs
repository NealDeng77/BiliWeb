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
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new System.DateTime(2019, 1, 1),
                ClinicID = "Test"
            };

            // Act
            var myNewData = new TechnicianModel(myData);

            // Assert
            Assert.AreEqual("John", myNewData.FirstName);
            Assert.AreEqual("Doe", myNewData.LastName);
            Assert.AreEqual(new System.DateTime(2019, 1, 1), myNewData.DateOfBirth);
            Assert.AreEqual("Test", myNewData.ClinicID);
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
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new System.DateTime(2019, 1, 1),
                ClinicID = "Test",
                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);


            // Assert
            Assert.AreEqual("John", myData.FirstName);
            Assert.AreEqual("Doe", myData.LastName);
            Assert.AreEqual(new System.DateTime(2019, 1, 1), myData.DateOfBirth);
            Assert.AreEqual("Test", myData.ClinicID);
            Assert.AreNotEqual(myData.Date, myDataNew.Date);

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
            Assert.IsNull(myData.FirstName);
            Assert.IsNull(myData.LastName);
            Assert.IsNull(myData.DateOfBirth);
            Assert.IsNull(myData.ClinicID);

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
            myData.FirstName = "John";
            myData.LastName = "Doe";
            myData.DateOfBirth = new System.DateTime(2019, 1, 1);
            myData.ClinicID = "Test";

            // Assert
            Assert.AreEqual("John", myData.FirstName);
            Assert.AreEqual("Doe", myData.LastName);
            Assert.AreEqual(new System.DateTime(2019, 1, 1), myData.DateOfBirth);
            Assert.AreEqual("Test", myData.ClinicID);
        }
    }
}
