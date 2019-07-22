using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Inventory
{
    [TestClass]
    public class InventoryCreateViewTests
    {
        [TestMethod]
        public void Inventory_Create_Default_Should_Pass()
        {
            // Arrange
            var myController = new InventoryController();

            // Act
            var result = myController.Create();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
