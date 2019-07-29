using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models.API
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
                ResultLogID = "ResultLogID",
                ResultDataID = "ResultDataID",
                ResultDataURI = "ResultDataURI"
            };

            // Assert
            Assert.AreEqual(10, result.Status);
            Assert.AreEqual("Message", result.Message);
            Assert.AreEqual("Photo", result.PhotoID);
            Assert.AreEqual("ResultLogID", result.ResultLogID);
            Assert.AreEqual("ResultDataID", result.ResultDataID);
            Assert.AreEqual("ResultDataURI", result.ResultDataURI);
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
                ResultLogID = "ResultLogID",
                ResultDataID = "ResultDataID",
                ResultDataURI = "ResultDataURI",
                ResultCode = "ResultCode"
            };

            var Status = result.Status;
            var Message = result.Message;
            var PhotoID = result.PhotoID;
            var ResultLogID = result.ResultLogID;
            var ResultDataID = result.ResultDataID;
            var ResultDataURI = result.ResultDataURI;
            var ResultCode = result.ResultCode;

            // Assert
            Assert.AreEqual(10, Status);
            Assert.AreEqual("Message", Message);
            Assert.AreEqual("Photo", PhotoID);
            Assert.AreEqual("ResultLogID", ResultLogID);
            Assert.AreEqual("ResultDataID", ResultDataID);
            Assert.AreEqual("ResultDataURI", ResultDataURI);
            Assert.AreEqual("ResultCode", ResultCode);
        }
    }
}
