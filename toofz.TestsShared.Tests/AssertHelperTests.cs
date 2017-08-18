using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared.Tests
{
    class AssertHelperTests
    {
        [TestClass]
        public class NormalizedAreEqual
        {
            [TestMethod]
            public void HaveDifferentLineEndings_DoesNotFail()
            {
                // Arrange
                var expected = "a\r\nb";
                var actual = "a\nb";

                // Act -> Assert
                AssertHelper.NormalizedAreEqual(expected, actual);
            }
        }
    }
}
