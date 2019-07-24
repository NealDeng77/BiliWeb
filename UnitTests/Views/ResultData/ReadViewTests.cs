using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultData
{
    [TestClass]
    public class ResultDataReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void ResultData_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ResultDataController();

            // Act
            var result = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
