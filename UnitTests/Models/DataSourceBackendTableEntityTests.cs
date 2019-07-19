﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class DataSourceBackendTableEntityTests
    {
        public TestContext TestContext { get; set; }

        #region Instantiate
        [TestMethod]
        public void DataSourceBackendTableEntity_Default_Instantiate_Should_Pass()
        {

            // Act
            var result = new DataSourceBackendTableEntity();

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void DataSourceBackendTableEntity_Default_Instantiate_With_Keys_Should_Pass()
        {

            // Act
            var result = new DataSourceBackendTableEntity("pk", "rk");

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void DataSourceBackendTableEntity_Default_Instantiate_With_Blob_Should_Pass()
        {
            // Arrange
            var blob = "abc";

            // Act
            var result = new DataSourceBackendTableEntity("pk", "rk", blob);

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void DataSourceBackendTableEntity_Default_Blob_Get_Should_Pass()
        {
            // Arrange
            var data = new DataSourceBackendTableEntity("pk", "rk", "123");

            // Act
            var result = data.Blob;

            // Assert
            Assert.IsNotNull(result, TestContext.TestName);
        }

        [TestMethod]
        public void DataSourceBackendTableEntity_Default_Blob_Set_Should_Pass()
        {
            // Arrange
            var data = new DataSourceBackendTableEntity("pk", "rk");
            var expect = "123";
            
            // Act
            data.Blob = expect;
            var result = data.Blob;

            // Assert
            Assert.AreEqual(expect, result, TestContext.TestName);
        }
        #endregion Instantiate
    }
}
