using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;

namespace UnitTests.Views.Inventory
{
    [TestClass]
    public class InventoryDeleteViewTest
    {
        [TestMethod]
        public void Inventory_Delete_InValid_Data_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new InventoryController();

            // Act
            var result = myController.Delete("bogus");

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
