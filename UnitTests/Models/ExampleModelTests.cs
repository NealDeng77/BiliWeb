using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class ExampleModelTests
    {
        /// <summary>
        /// Stand up a new Model, make sure it is not null
        /// </summary>
        [TestMethod]
        public void Example_Default_Should_Pass()
        {
            // Arrange

            // Act
            var myTest = new ExampleModel();

            // Assert
            Assert.IsNotNull(myTest);
        }
    }
}
