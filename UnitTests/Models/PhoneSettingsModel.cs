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
        public void PhoneSettings_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new PhoneSettingsModel();

            // Assert
            Assert.IsNotNull(result);
        }
        
    }
}
