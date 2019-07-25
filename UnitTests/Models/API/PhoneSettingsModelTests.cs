using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class PhoneSettingsModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void PhoneSettings_InValid_Empty_Phone_Should_Fail()
        {
            // Arrange
            var data = new PhoneModel();

            // Act
            var result = new PhoneSettingsModel(data);

            // Assert
            Assert.IsNotNull(result);
        }
        
    }
}
