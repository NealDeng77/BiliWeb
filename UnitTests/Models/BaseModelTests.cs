using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class BaseModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Base_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Get test for Base Model
        /// </summary>
        [TestMethod]
        public void Base_Get_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel();

            // Assert
            Assert.AreNotEqual("",result.ID);
            Assert.AreNotEqual(System.DateTime.MinValue, result.Date);
        }


        /// <summary>
        /// Set test for Base Model
        /// </summary>
        [TestMethod]
        public void Base_Set_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BaseModel
            {
                ID = "123",
                Date = System.DateTime.MinValue
            };

            // Assert
            Assert.AreEqual("123", result.ID);
            Assert.AreEqual(System.DateTime.MinValue, result.Date);
        }
    }
}
