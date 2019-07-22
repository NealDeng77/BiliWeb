using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Inventory
{
    [TestClass]
    public class InventoryViewTest
    {
        [TestMethod]
        public void Inventory_Update_Default_Should_Pass()
        {
            // Arrange
            var myController = new InventoryController();

            // Act
            var result = myController.Update("abc");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
