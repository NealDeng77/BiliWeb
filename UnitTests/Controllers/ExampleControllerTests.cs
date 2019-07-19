using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UnitTests.Controllers
{
    [TestClass]
    public class ExampleControlerTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Index();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion IndexTests

        #region CreateTests

        /// <summary>
        /// Ensure the Create Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Create_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Create();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Create Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Create_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = new ExampleModel();

            // Act
            var myTest = myController.Create(myData);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion CreateTests

        #region ReadTests
        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Read(null);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Read of Null Data should Fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = BiliWeb.Backend.ExampleBackend.Instance.Index().FirstOrDefault();

            // Act
            var myTest = myController.Read(myData.ID) as ViewResult;

            // Assert
            Assert.IsNotNull(myTest.Model);
        }

        //             var myData = BiliWeb.Backend.BiliWeb.Backend.DataSourceBackend.Instance.Reset();.Instance.ExampleBackend.Index().FirstOrDefault();
        //            BiliWeb.Backend.BiliWeb.Backend.DataSourceBackend.Instance.Reset();

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var result = (NotFoundResult)myController.Read(null);

            // Reset

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Read_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Read("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }
        #endregion ReadTests

        #region UpdateTests
        /// <summary>
        /// Ensure the Update Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Get_InValid_ID_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Update("abc");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Update Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void Example_Update_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = new ExampleModel();

            // Act
            var myTest = myController.Update(myData);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Update of Null Data should Fail
        /// 
        /// Success on Update Jups to Index page
        /// </summary>
        [TestMethod]
        public void Example_Update_Get_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = BiliWeb.Backend.ExampleBackend.Instance.Index().FirstOrDefault();

            // Act
            var result = myController.Update(myData.ID) as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        /// Update of Null Data should Fail
        /// 
        /// Success on Update Jups to Index page
        /// </summary>
        [TestMethod]
        public void Example_Update_Post_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ExampleController();
            var myData = BiliWeb.Backend.ExampleBackend.Instance.Index().FirstOrDefault();
            var myTestData = new ExampleModel(myData)
            {
                Name = "New",
                ID = myData.ID
            };

            // Act
            var result = myController.Update(myTestData) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Index", result.ActionName);
        }

        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Delete(null);

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void Example_Delete_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var myController = new ExampleController();

            // Act
            var myTest = myController.Delete("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        [TestMethod]
        public void Example_Delete_Get_Null_Id_Should_Return_Error()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            var result = controller.Delete((string)null) as NotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void Example_Delete_Invalid_Null_Data_Should_Return_Error()
        {
            // Arrange
            var controller = new ExampleController();
            string id = "bogus";

            // Act
            var result = controller.Delete(id) as NotFoundResult;

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void Example_Delete_Get_Default_Should_Pass()
        {
            // Arrange
            var controller = new ExampleController();

            string id = BiliWeb.Backend.DataSourceBackend.Instance.ExampleBackend.Index().FirstOrDefault().ID;

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Reset BiliWeb.Backend.DataSourceBackend.Instance.Reset();
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion DeleteTests

        #region DeletePostRegion
        [TestMethod]
        public void Example_Delete_Post_Invalid_Model_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ExampleController();
            var data = new ExampleModel();

            // Make ModelState Invalid
            controller.ModelState.AddModelError("test", "test");

            // Act
            var result = controller.DeleteConfirmed(data.ID) as NotFoundResult;

            // Assert
            Assert.AreEqual(404,result.StatusCode);
        }

        [TestMethod]
        public void Example_Delete_Post_Null_Data_Should_Return_Error()
        {
            // Arrange
            var controller = new ExampleController();

            // Act
            var result = controller.DeleteConfirmed(null) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Error", result.ActionName);
        }

        [TestMethod]
        public void Example_Delete_Post_Null_Id_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ExampleController();
            ExampleModel dataNull = new ExampleModel
            {
                // Make data.Id = null
                ID = null
            };

            // Act
            var result = controller.DeleteConfirmed(dataNull.ID) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Error", result.ActionName);
        }

        [TestMethod]
        public void Example_Delete_Post_Empty_Id_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ExampleController();
            ExampleModel dataEmpty = new ExampleModel
            {

                // Make data.Id empty
                ID = ""
            };

            // Act
            var result = controller.DeleteConfirmed(dataEmpty.ID) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Error", result.ActionName);
        }

        [TestMethod]
        public void Example_Delete_Post_Default_Should_Return_Index_Page()
        {
            // Arrange
            var controller = new ExampleController();

            // Get default student
            var defaultData = BiliWeb.Backend.DataSourceBackend.Instance.ExampleBackend.Index().FirstOrDefault();
            ExampleModel data = new ExampleModel(defaultData);

            // Act
            var result = controller.DeleteConfirmed(data.ID) as NotFoundResult;

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }
        #endregion DeletePostRegion
    }
}
