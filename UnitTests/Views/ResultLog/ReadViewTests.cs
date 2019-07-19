using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.ResultLog
{
    [TestClass]
    public class ResultLogReadViewTest
    {
        /// <summary>
        /// Read Invalid Data should Fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Read_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var myTest = myController.Read("bogus");

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
