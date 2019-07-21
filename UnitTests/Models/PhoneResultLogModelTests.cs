using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class PhoneResultLogModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneResultLogModel();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Set test for PhoneResultLog Model
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Set_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneResultLogModel
            {
                Status = 10,
                Message = "Message",
                PhotoID = "Photo",
                ResultLogID = "ResultLogID"
            };

            // Assert
            Assert.AreEqual(10, result.Status);
            Assert.AreEqual("Message", result.Message);
            Assert.AreEqual("Photo", result.PhotoID);
            Assert.AreEqual("ResultLogID", result.ResultLogID);
        }

        /// <summary>
        /// Set test for PhoneResultLog Model
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Get_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneResultLogModel
            {
                Status = 10,
                Message = "Message",
                PhotoID = "Photo",
                ResultLogID = "ResultLogID"
            };

            var Status = result.Status;
            var Message = result.Message;
            var PhotoID = result.PhotoID;
            var ResultLogID = result.ResultLogID;

            // Assert
            Assert.AreEqual(10, Status);
            Assert.AreEqual("Message", Message);
            Assert.AreEqual("Photo", PhotoID);
            Assert.AreEqual("ResultLogID", ResultLogID);
        }
    }
}