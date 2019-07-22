using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Inventory
{
    [TestClass]
    public class InventoryIndexViewTest
    {
        [TestMethod]
        public void Inventory_Index_Default_Should_Pass()
        {
            // Arrange
            var myController = new InventoryController();

            // Act
            var result = myController.Index();

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
