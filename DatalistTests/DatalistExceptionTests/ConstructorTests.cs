﻿using Datalist;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatalistTests.DatalistExceptionTests
{
    [TestClass]
    public class ConstructorTests
    {
        #region Tests

        [TestMethod]
        public void MessageTest()
        {
            var expected = "Test message";
            var exception = new DatalistException(expected);
            Assert.AreEqual(expected, exception.Message);
        }

        #endregion
    }
}
