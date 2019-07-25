using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;
using BiliWeb.Controllers;
using BiliWeb.Backend;
using System.Collections.Generic;

namespace UnitTests.Controllers.API
{
    [TestClass]
    public class PhoneResultLogControlerTests
    {
        #region PostTests

        /// <summary>
        /// Ensure the Post Method on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_Default_Should_Pass()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            // Act
            var result = myController.Post(null);

            // Reset

            // Assert
            Assert.AreEqual(0,result.Status);
        }

        //[TestMethod]
        //public void PhoneResultLog_Post_Post_Invalid_Model_Should_Send_Back_For_Edit()
        //{
        //    // Arrange
        //    var controller = new PhoneResultLogController();
        //    var data = new PhoneResultLogModel();

        //    // Make ModelState Invalid
        //    controller.ModelState.AddModelError("test", "test");

        //    // Act
        //    var result = controller.Post(data) as RedirectToActionResult;

        //    // Assert
        //    Assert.AreEqual("Error", result.ActionName);
        //}

        /// <summary>
        /// Ensure the Post Method Post on the controller returns and is not null
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_Valid_ResultLog_Should_Pass()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = clinic[0].ID,
                PhoneID = phone[0].ID,
                UserID = tech[0].ID,
                BilirubinValue = 15
            };

            // Act
            var result = myController.Post(myData);

            // Access the Record to ensure it was created
            var myNewLog = BiliWeb.Backend.DataSourceBackend.Instance.ResultLogBackend.Read(myData.ID);

            // Reset
            BiliWeb.Backend.DataSourceBackend.Instance.Reset();

            // Assert
            Assert.AreEqual(1,result.Status);
            Assert.AreEqual(myData.ID, myNewLog.ID);
            Assert.AreEqual(myData.BilirubinValue, myNewLog.BilirubinValue);
        }

        /// <summary>
        /// Post Errors
        /// Bad Bilirubin Range too Low
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_InValid_Bilirubiun_Range_Low_Should_Fail()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = clinic[0].ID,
                PhoneID = phone[0].ID,
                UserID = tech[0].ID,
                BilirubinValue = -1
            };

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Status);
        }

        /// <summary>
        /// Post Errors
        /// Bad Bilirubin Range too Low
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_InValid_Bilirubiun_Range_High_Should_Fail()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = clinic[0].ID,
                PhoneID = phone[0].ID,
                UserID = tech[0].ID,
                BilirubinValue = 1000
            };

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Status);
        }

        /// <summary>
        /// Post Errors
        /// Bad ClinicID
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_InValid_ClinicID_Should_Fail()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = "Bogus",
                PhoneID = phone[0].ID,
                UserID = tech[0].ID,
                BilirubinValue = 1
            };

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Status);
        }

        /// <summary>
        /// Post Errors
        /// Bad PhoneID
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_InValid_PhoneID_Should_Fail()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = clinic[0].ID,
                PhoneID = "bogus",
                UserID = tech[0].ID,
                BilirubinValue = 1
            };

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Status);
        }

        /// <summary>
        /// Post Errors
        /// Bad UserID
        /// </summary>
        [TestMethod]
        public void PhoneResultLog_Post_InValid_UserID_Should_Fail()
        {
            // Arrange
            var myController = new PhoneResultLogController();

            //Call backend to technicians
            TechnicianBackend TechnicianData = TechnicianBackend.Instance;
            List<TechnicianModel> tech = TechnicianData.Index();

            //Call backend to phones
            PhoneBackend PhoneData = PhoneBackend.Instance;
            List<PhoneModel> phone = PhoneData.Index();

            //Call backend to clinics
            ClinicBackend ClinicData = ClinicBackend.Instance;
            List<ClinicModel> clinic = ClinicData.Index();

            var myData = new ResultLogModel
            {
                ClinicID = clinic[0].ID,
                PhoneID = phone[0].ID,
                UserID = "bugus",
                BilirubinValue = 1
            };

            // Act
            var result = myController.Post(myData);

            // Reset

            // Assert
            Assert.AreEqual(0, result.Status);
        }

        #endregion PostTests

    }
}
