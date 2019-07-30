using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Backend;
using System.Linq;

namespace UnitTests.Backend
{
    [TestClass]
    public class ResultDataHelperTests
    {
        #region ConvertResultCodeToIDTests
        /// <summary>
        /// Convert Valid ID to Value
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ConvertResultCodeToID_Valid_Should_Pass()
        {
            // Arrange
            var data = new ResultDataModel
            {
                ResultCode = "ResultCode"
            };

            DataSourceBackend.Instance.ResultDataBackend.Create(data);

            // Act
            var result = ResultDataHelper.ConvertResultCodeToID(data.ResultCode);

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(data.ID, result);
        }

        /// <summary>
        /// Convert InValid ID to empty String
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_ConvertResultCodeToID_InValid_Bogus_Should_Fail()
        {
            // Arrange
            var data = new ResultDataModel
            {
                ResultCode = "ResultCode"
            };

            DataSourceBackend.Instance.ResultDataBackend.Create(data);

            // Act
            var result = ResultDataHelper.ConvertResultCodeToID("Bogus");

            // Reset
            DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        #endregion ConvertResultCodeToIDTests

        #region RandomNumberTests
        /// <summary>
        /// Generates a Random Number
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_RandomNumber_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ResultDataHelper.RandomNumber(1,1);

            // Reset

            // Assert
            Assert.AreEqual(1, result);
        }

        #endregion RandomNumberTests

        #region GenerateResultCodeTests

        /// <summary>
        /// Generates a Result Code
        /// </summary>
        [TestMethod]
        public void ResultDataHelper_GenerateResultCode_Valid_Should_Pass()
        {
            // Arrange

            // Act
            var result = ResultDataHelper.GenerateResultCode();

            // Reset

            // Assert
            Assert.AreEqual(6, result.Length);
        }

        #endregion GenerateResultCodeTests

    }
}



    

 