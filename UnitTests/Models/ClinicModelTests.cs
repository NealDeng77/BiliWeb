using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class ClinicModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Clinic_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ClinicModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Instantiate Model with Data
        /// </summary>
        [TestMethod]
        public void Clinic_Constructor_Data_Valid_Should_Pass()
        {
            // Arrange
            var myData = new ClinicModel
            {
                Name = "Bellevue Hospital",
                Address = "13 Bellevue Dr.",
                City = "Bellevue",
                Country = "USA",
                Contact = "John Appleseed",
                Phone = "+14254254252",
                Email = "jappleseed@gmail.com",
                Notes = "Newly opened",
                Latitude = "6.2117902",
                Longitude = "6.7115102"
        };

            // Act
            var myNewData = new ClinicModel(myData);

            // Assert
            Assert.AreEqual("Bellevue Hospital", myNewData.Name);
            Assert.AreEqual("13 Bellevue Dr.", myNewData.Address);
            Assert.AreEqual("Bellevue", myNewData.City);
            Assert.AreEqual("USA", myNewData.Country);
            Assert.AreEqual("John Appleseed", myNewData.Contact);
            Assert.AreEqual("+14254254252", myNewData.Phone);
            Assert.AreEqual("jappleseed@gmail.com", myNewData.Email);
            Assert.AreEqual("Newly opened", myNewData.Notes);
            Assert.AreEqual("6.2117902", myNewData.Latitude);
            Assert.AreEqual("6.7115102", myNewData.Longitude);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Clinic_Update_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myData = new ClinicModel();

            // Act
            var result = myData.Update(null);

            // Assert
            Assert.AreEqual(false,result);
        }

        /// <summary>
        /// Update Model with bogus data should Fail
        /// </summary>
        [TestMethod]
        public void Clinic_Update_Valid_Data_Good_Should_Pass()
        {
            // Arrange
            var myData = new ClinicModel();
            var myDataNew = new ClinicModel
            {
                Name = "Bellevue Hospital",
                Address = "13 Bellevue Dr.",
                City = "Bellevue",
                Country = "USA",
                Contact = "John Appleseed",
                Phone = "+14254254252",
                Email = "jappleseed@gmail.com",
                Notes = "Newly opened",
                Latitude = "6.2117902",
                Longitude = "6.7115102",
                ID = myData.ID
            };

            // Act
            myData.Update(myDataNew);
            myData.Date = myData.Date.AddSeconds(-5);

            // Assert
            Assert.AreEqual("Bellevue Hospital", myData.Name);
            Assert.AreEqual("13 Bellevue Dr.", myData.Address);
            Assert.AreEqual("Bellevue", myData.City);
            Assert.AreEqual("USA", myData.Country);
            Assert.AreEqual("John Appleseed", myData.Contact);
            Assert.AreEqual("+14254254252", myData.Phone);
            Assert.AreEqual("jappleseed@gmail.com", myData.Email);
            Assert.AreEqual("Newly opened", myData.Notes);
            Assert.AreEqual("6.2117902", myData.Latitude);
            Assert.AreEqual("6.7115102", myData.Longitude);

            Assert.AreNotEqual(myData.Date, myDataNew.Date);
        }

        /// <summary>
        /// Get test for Model
        /// </summary>
        [TestMethod]
        public void Clinic_Get_Should_Pass()
        {
            // Arrange
            var myData = new ClinicModel();

            // Act

            // Assert
            Assert.IsNull(myData.Name);
            Assert.IsNull(myData.Address);
            Assert.IsNull(myData.City);
            Assert.IsNull(myData.Country);
            Assert.IsNull(myData.Contact);
            Assert.IsNull(myData.Phone);
            Assert.IsNull(myData.Email);
            Assert.IsNull(myData.Notes);
            Assert.IsNull(myData.Latitude);
            Assert.IsNull(myData.Longitude);

        }

        /// <summary>
        /// Set test for Model
        /// </summary>
        [TestMethod]
        public void Clinic_Set_Should_Pass()
        {
            // Arrange
            var myData = new ClinicModel();

            // Act
            myData.Name = "Bellevue Hospital";
            myData.Address = "13 Bellevue Dr.";
            myData.City = "Bellevue";
            myData.Country = "USA";
            myData.Contact = "John Appleseed";
            myData.Phone = "+14254254252";
            myData.Email = "jappleseed@gmail.com";
            myData.Notes = "Newly opened";
            myData.Latitude = "6.2117902";
            myData.Longitude = "6.7115102";

            // Assert
            Assert.AreEqual("Bellevue Hospital", myData.Name);
            Assert.AreEqual("13 Bellevue Dr.", myData.Address);
            Assert.AreEqual("Bellevue", myData.City);
            Assert.AreEqual("USA", myData.Country);
            Assert.AreEqual("John Appleseed", myData.Contact);
            Assert.AreEqual("+14254254252", myData.Phone);
            Assert.AreEqual("jappleseed@gmail.com", myData.Email);
            Assert.AreEqual("Newly opened", myData.Notes);
            Assert.AreEqual("6.2117902", myData.Latitude);
            Assert.AreEqual("6.7115102", myData.Longitude);

            // TODO:  Add an Assert for each attribute
        }
    }
}
