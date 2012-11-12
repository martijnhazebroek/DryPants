using System;
using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    internal class EnumExtensionsTests
    {
        [TestClass]
        public class IsOneOfTests
        {
            [TestMethod]
            public void EnumValue_IsOneOfSelf()
            {
                Assert.IsTrue(ConsoleColor.Blue.IsOneOf(ConsoleColor.Blue));
            }

            [TestMethod]
            public void EnumValue_IsOneOfSelfAndOther()
            {
                Assert.IsTrue(ConsoleColor.Blue.IsOneOf(ConsoleColor.Blue, ConsoleColor.Red));
            }

            [TestMethod]
            public void EnumValue_IsNotOneOfOther()
            {
                Assert.IsFalse(ConsoleColor.Blue.IsOneOf(ConsoleColor.Red));
            }
        }
    }
}