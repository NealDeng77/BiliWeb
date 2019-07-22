using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            // Act
            var result = new ErrorViewModel();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
