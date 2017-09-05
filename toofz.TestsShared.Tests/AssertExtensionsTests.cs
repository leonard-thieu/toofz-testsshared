using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    class AssertExtensionsTests
    {
        [TestClass]
        public class NormalizedAreEqual
        {
            [TestMethod]
            public void AssertIsNull_ThrowsArgumentNullException()
            {
                // Arrange
                Assert assert = null;
                string expected = "expected";
                string actual = "actual";

                // Act -> Assert
                Assert.ThrowsException<ArgumentNullException>(() =>
                {
                    AssertExtensions.NormalizedAreEqual(assert, expected, actual);
                });
            }

            [TestMethod]
            public void ExpectedIsNull_ThrowsAssertFailedException()
            {
                // Arrange
                Assert assert = Assert.That;
                string expected = null;
                string actual = "actual";

                // Act -> Assert
                Assert.ThrowsException<AssertFailedException>(() =>
                {
                    AssertExtensions.NormalizedAreEqual(assert, expected, actual);
                });
            }

            [TestMethod]
            public void ActualIsNull_ThrowsAssertFailedException()
            {
                // Arrange
                Assert assert = Assert.That;
                string expected = "expected";
                string actual = null;

                // Act -> Assert
                Assert.ThrowsException<AssertFailedException>(() =>
                {
                    AssertExtensions.NormalizedAreEqual(assert, expected, actual);
                });
            }

            [TestMethod]
            public void ExpectedIsNullAndActualIsNull_DoesNotThrow()
            {
                // Arrange
                Assert assert = Assert.That;
                string expected = null;
                string actual = null;

                // Act -> Assert
                AssertExtensions.NormalizedAreEqual(assert, expected, actual);
            }

            [TestMethod]
            public void HaveDifferentLineEndings_DoesNotThrow()
            {
                // Arrange
                Assert assert = Assert.That;
                var expected = "a\r\nb";
                var actual = "a\nb";

                // Act -> Assert
                AssertExtensions.NormalizedAreEqual(assert, expected, actual);
            }
        }
    }
}
