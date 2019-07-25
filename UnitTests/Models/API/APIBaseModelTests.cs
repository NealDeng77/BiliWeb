using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models.API
{
    [TestClass]
    public class APIBaseModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void APIBaseModel_InValid_Empty_Phone_Should_Fail()
        {
            // Arrange

            // Act
            var result = new APIBaseModel();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
