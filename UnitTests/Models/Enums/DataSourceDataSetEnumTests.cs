﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiliWeb.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class DataSourceDataSetEnumTests
    {
        public TestContext TestContext { get; set; }

        #region Instantiate
        [TestMethod]
        public void DataSourceDataSetEnum_Values_Should_Pass()
        {
            // Assert

            // Make sure there are no additional values
            var enumCount = DataSourceDataSetEnum.GetNames(typeof(DataSourceDataSetEnum)).Length;
            Assert.AreEqual(3, enumCount, TestContext.TestName);

            // Check each value against their expected value.
            Assert.AreEqual(2, (int)DataSourceDataSetEnum.UnitTest, TestContext.TestName);
            Assert.AreEqual(1, (int)DataSourceDataSetEnum.Demo, TestContext.TestName);
            Assert.AreEqual(0, (int)DataSourceDataSetEnum.Default, TestContext.TestName);
        }
        #endregion Instantiate
    }
}
