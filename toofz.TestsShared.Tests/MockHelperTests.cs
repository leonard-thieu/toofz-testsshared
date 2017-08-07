using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace toofz.TestsShared.Tests
{
    class MockHelperTests
    {
        [TestClass]
        public class MockSet
        {
            [TestMethod]
            public void DataIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                IEnumerable<object> data = null;

                // Act
                var ex = Record.Exception(() =>
                {
                    MockHelper.MockSet(data);
                });

                // Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }

            [TestMethod]
            public void DataIsNotNull_ReturnsMockDbSet()
            {
                // Arrange
                IEnumerable<object> data = new[]
                {
                    new object(),
                };

                // Act
                var mockDbSet = MockHelper.MockSet(data);

                // Assert
                Assert.IsInstanceOfType(mockDbSet, typeof(Mock<DbSet<object>>));
            }

            [TestMethod]
            public void NoParams_ReturnsMockDbSet()
            {
                // Arrange -> Act
                var mockDbSet = MockHelper.MockSet<object>();

                // Assert
                Assert.IsInstanceOfType(mockDbSet, typeof(Mock<DbSet<object>>));
            }

            [TestMethod]
            public void EntitiesIsNotNull_ReturnsMockDbSet()
            {
                // Arrange
                var entity1 = new object();
                var entity2 = new object();

                // Act
                var mockDbSet = MockHelper.MockSet(entity1, entity2);

                // Assert
                Assert.IsInstanceOfType(mockDbSet, typeof(Mock<DbSet<object>>));
            }
        }
    }
}
