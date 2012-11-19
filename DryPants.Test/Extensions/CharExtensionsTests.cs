using DryPants.Extensions;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    internal class CharExtensionsTests
    {
        [TestClass]
        public class ToAlphabetIndexTest
        {
            [TestMethod]
            public void UpperCaseA_HasIndexZero()
            {
                Assert.AreEqual(0, 'A'.ToAlphabetIndex());
            }  
            
            [TestMethod]
            public void LowerCaseA_HasIndexZero()
            {
                Assert.AreEqual(0, 'a'.ToAlphabetIndex());
            } 
            
            [TestMethod]
            public void UpperCaseZ_HasIndexZero()
            {
                Assert.AreEqual(25, 'Z'.ToAlphabetIndex());
            }  
            
            [TestMethod]
            public void LowerCaseZ_HasIndexZero()
            {
                Assert.AreEqual(25, 'z'.ToAlphabetIndex());
            }    
            
            [TestMethod]
            public void NotInAlphabeth_HasIndexMinus1()
            {
                Assert.AreEqual(-1, '-'.ToAlphabetIndex());
            }
        } 
        
        [TestClass]
        public class UpToTests
        {
            [TestMethod]
            public void UpperCaseA_UpToUpperCaseA_ReturnsUpperCaseA()
            {
                var expected = new[] {'A'};

                char[] actual = 'A'.UpTo('A');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void UpperCaseA_UpToUpperCaseZ_ReturnsUpperCaseAlphabet()
            {
                char[] expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] actual = 'A'.UpTo('Z');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void UpperCaseZ_UpToUpperCaseA_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};
                    
                char[] actual = 'Z'.UpTo('A');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void UpperCaseZ_UpToLowerCaseA_ReturnsZWithSpecialCharsUptoA()
            {
                var expected = @"Z[\]^_`a".ToCharArray();

                char[] actual = 'Z'.UpTo('a');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void UpperCaseA_UpToLowerCaseA_ReturnsAlphabethWithSpecialCharsUpToLowerCaseA()
            {
                var expected = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`a".ToCharArray();

                char[] actual = 'A'.UpTo('a');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void LowerCaseA_UpToLowerCaseZ_ReturnsLowerCaseAlphabet()
            {
                char[] expected = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

                char[] actual = 'a'.UpTo('z');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void LowerCaseA_UpToUpperCaseZ_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};

                char[] actual = 'a'.UpTo('Z');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void LowerCaseA_UpToLowerCaseA_ReturnsLowerCaseA()
            {
                var expected = new[] {'a'};

                char[] actual = 'a'.UpTo('a');

                CollectionAssert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void LowerCaseA_UpToUpperCaseA_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};

                char[] actual = 'a'.UpTo('A');

                CollectionAssert.AreEqual(expected, actual);
            } 
            
            [TestMethod]
            public void Dash_UpToUnderscore_ReturnsExpectedChars()
            {
                char[] expected = @"-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_".ToCharArray();
                char[] actual = '-'.UpTo('_');

                CollectionAssert.AreEqual(expected, actual);
            }
        }
    }
}