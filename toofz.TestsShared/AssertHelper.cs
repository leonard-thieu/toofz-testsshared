using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared
{
    public static class AssertHelper
    {
        public static void NormalizedAreEqual(string expected, string actual)
        {
            if (expected != null && actual != null)
            {
                expected = Regex.Replace(expected, "\r?\n", "\r\n");
                actual = Regex.Replace(actual, "\r?\n", "\r\n");
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
