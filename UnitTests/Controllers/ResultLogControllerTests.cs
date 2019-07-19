using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace UnitTests.Controllers
{
    [TestClass]
    public class ResultLogControlerTests
    {
        #region IndexTests
        /// <summary>
        /// Ensure the Default Index page on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Index_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();

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
        public void ResultLog_Create_Get_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var myTest = myController.Create();

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        [TestMethod]
        public void ResultLog_Create_Post_Invalid_Model_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ResultLogController();
            var data = new ResultLogModel();

            // Make ModelState Invalid
            controller.ModelState.AddModelError("test", "test");

            // Act
            var result = controller.Create(data) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Error", result.ActionName);
        }

        /// <summary>
        /// Ensure the Create Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Create_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();
            var myData = new ResultLogModel();

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
        public void ResultLog_Read_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

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
        public void ResultLog_Read_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();
            var myData = BiliWeb.Backend.ResultLogBackend.Instance.Index().FirstOrDefault();

            // Act
            var myTest = myController.Read(myData.ID) as ViewResult;

            // Assert
            Assert.IsNotNull(myTest.Model);
        }

        //             var myData = BiliWeb.Backend.BiliWeb.Backend.DataSourceBackend.Instance.Reset();.Instance.ResultLogBackend.Index().FirstOrDefault();
        //            BiliWeb.Backend.BiliWeb.Backend.DataSourceBackend.Instance.Reset();

        /// <summary>
        /// Ensure the Read Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Read_Get_InValid_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

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
        public void ResultLog_Read_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

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
        public void ResultLog_Update_Get_InValid_ID_Bogus_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var myTest = myController.Update("abc");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        [TestMethod]
        public void ResultLog_Update_Post_Invalid_Model_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ResultLogController();
            var data = new ResultLogModel();

            // Make ModelState Invalid
            controller.ModelState.AddModelError("test", "test");

            // Act
            var result = controller.Update(data) as NotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        /// <summary>
        /// Ensure the Update Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();
            var myData = new ResultLogModel();

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
        public void ResultLog_Update_Get_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();
            var myData = BiliWeb.Backend.ResultLogBackend.Instance.Index().FirstOrDefault();

            // Act
            var result = myController.Update(myData.ID) as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        /// <summary>
        /// Update of Null Data should Fail
        /// 
        /// Success on Update Jumps to Index page
        /// </summary>
        [TestMethod]
        public void ResultLog_Update_Post_Valid_Data_Should_Pass()
        {
            // Arrange
            var myController = new ResultLogController();
            var myData = BiliWeb.Backend.ResultLogBackend.Instance.Index().FirstOrDefault();
            var myTestData = new ResultLogModel(myData)
            {
                Name = "New",
                ID = myData.ID
            };

            // Act
            var result = myController.Update(myTestData) as RedirectToActionResult;

            //Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual("Index", result.ActionName);
        }

        #endregion UpdateTests

        #region DeleteTests
        /// <summary>
        /// Ensure the Delete Method with no data should fail
        /// </summary>
        [TestMethod]
        public void ResultLog_Delete_Get_Data_Null_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

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
        public void ResultLog_Delete_Get_Data_In_Valid_Should_Fail()
        {
            // Arrange
            var myController = new ResultLogController();

            // Act
            var myTest = myController.Delete("bogus");

            // Reset

            // Assert
            Assert.IsNotNull(myTest);
        }

        [TestMethod]
        public void ResultLog_Delete_Get_Null_Id_Should_Return_Error()
        {
            // Arrange
            var controller = new ResultLogController();

            // Act
            var result = controller.Delete((string)null) as NotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void ResultLog_Delete_Invalid_Null_Data_Should_Return_Error()
        {
            // Arrange
            var controller = new ResultLogController();
            string id = "bogus";

            // Act
            var result = controller.Delete(id) as NotFoundResult;

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void ResultLog_Delete_Get_Default_Should_Pass()
        {
            // Arrange
            var controller = new ResultLogController();

            string id = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Index().FirstOrDefault().ID;

            // Act
            ViewResult result = controller.Delete(id) as ViewResult;

            // Reset 
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ResultLog_Delete_Get_Default_Should_Return_Error_Message()
        {
            // Arrange
            var controller = new ResultLogController();

            // Get default student
            var data = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Index().FirstOrDefault();

            // Act
            var result = controller.Delete(data.ID, true) as ViewResult;

            // Reset

            // Assert
            Assert.IsNotNull(result.ViewData);
        }

        [TestMethod]
        public void ResultLog_Delete_Get_Default_Should_Return_Data()
        {
            // Arrange
            var controller = new ResultLogController();

            // Get default student
            var data = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Index().FirstOrDefault();

            // Act
            var result = controller.Delete(data.ID, true) as ViewResult;

            // Reset

            // Assert
            Assert.IsNotNull(result.ViewData);
        }
        #endregion DeleteTests

        #region DeletePostRegion
        [TestMethod]
        public void ResultLog_Delete_Post_Invalid_Model_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ResultLogController();
            var data = new ResultLogModel();

            // Make ModelState Invalid
            controller.ModelState.AddModelError("test", "test");

            // Act
            var result = controller.DeleteConfirmed(data.ID) as NotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void ResultLog_Delete_Post_Null_Data_Should_Return_Error()
        {
            // Arrange
            var controller = new ResultLogController();

            // Act
            var result = controller.DeleteConfirmed(null) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Error", result.ActionName);
        }

        [TestMethod]
        public void ResultLog_Delete_Post_Null_Id_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ResultLogController();
            ResultLogModel dataNull = new ResultLogModel
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
        public void ResultLog_Delete_Post_Empty_Id_Should_Send_Back_For_Edit()
        {
            // Arrange
            var controller = new ResultLogController();
            ResultLogModel dataEmpty = new ResultLogModel
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
        public void ResultLog_Delete_Post_Default_Should_Return_Index_Page()
        {
            // Arrange
            var controller = new ResultLogController();

            // Get default student
            var defaultData = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Index().FirstOrDefault();
            ResultLogModel data = new ResultLogModel(defaultData);

            // Act
            var result = controller.DeleteConfirmed(data.ID) as NotFoundResult;

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        /// <summary>
        /// Delete the record
        /// This will remove the record from the list,
        /// So Get a record
        /// Call for delete on the record ID
        /// Then call for a read on the record ID
        /// The read should fail if the data was deleted
        /// </summary>
        [TestMethod]
        public void ResultLog_Delete_Post_Valid_Should_Delete()
        {
            // Arrange
            var controller = new ResultLogController();

            // Get default student
            var data = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Index().FirstOrDefault();

            // Act
            var result = controller.DeleteConfirmed(data.ID) as ViewResult;
            var dataExist = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Read(data.ID);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.IsNull(dataExist);
        }
        #endregion DeletePostRegion
    }
}
