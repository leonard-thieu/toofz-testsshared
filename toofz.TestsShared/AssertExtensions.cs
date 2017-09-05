using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace toofz.TestsShared
{
    public static class AssertExtensions
    {
        public static void NormalizedAreEqual(this Assert assert, string expected, string actual)
        {
            if (assert == null)
                throw new ArgumentNullException(nameof(assert));

            if (expected != null && actual != null)
            {
                expected = Regex.Replace(expected, "\r?\n", "\r\n");
                actual = Regex.Replace(actual, "\r?\n", "\r\n");
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
