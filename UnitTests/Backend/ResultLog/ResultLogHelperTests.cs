using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Backend;

namespace UnitTests.Backend
{
    [TestClass]
    public class ResultLogHelperTests
    {
        /// <summary>
        /// Convert Valid ID to Value
        /// </summary>
        [TestMethod]
        public void ResultLogHelper_ConvertIDtoString_Valid_Should_Pass()
        {
            // Arrange
            var data = new ResultLogModel
            {
                BilirubinValue = 55
            };
            DataSourceBackend.Instance.ResultLogBackend.Create(data);

            // Act
            var result = ResultLogHelper.ConvertIDtoString(data.ID);

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("55",result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void ResultLogHelper_ConvertIDtoString_InValid_Null_Should_Fail()
        {
            // Arrange

            // Act
            var result = ResultLogHelper.ConvertIDtoString(null);

            // Reset

            // Assert
            Assert.AreEqual(string.Empty,result);
        }

        /// <summary>
        /// Convert with Null should Fail
        /// </summary>
        [TestMethod]
        public void ResultLogHelper_ConvertIDtoString_InValid_Bogus_Should_Fail()
        {
            // Arrange

            // Act
            var result = ResultLogHelper.ConvertIDtoString("bogus");

            // Reset

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}
