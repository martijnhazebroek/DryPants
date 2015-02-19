using DryPants.Extensions;
using JetBrains.Annotations;
using Xunit;

namespace DryPants.Test.Extensions
{
    [UsedImplicitly]
    internal class CharExtensionsTests
    {
        
        public class ToAlphabetIndexTest
        {
            [Fact]
            public void UpperCaseA_HasIndexZero()
            {
                Assert.Equal(0, 'A'.ToAlphabetIndex());
            }  
            
            [Fact]
            public void LowerCaseA_HasIndexZero()
            {
                Assert.Equal(0, 'a'.ToAlphabetIndex());
            } 
            
            [Fact]
            public void UpperCaseZ_HasIndexZero()
            {
                Assert.Equal(25, 'Z'.ToAlphabetIndex());
            }  
            
            [Fact]
            public void LowerCaseZ_HasIndexZero()
            {
                Assert.Equal(25, 'z'.ToAlphabetIndex());
            }    
            
            [Fact]
            public void NotInAlphabeth_HasIndexMinus1()
            {
                Assert.Equal(-1, '-'.ToAlphabetIndex());
            }
        } 
        public class UpToTests
        {
            [Fact]
            public void UpperCaseA_UpToUpperCaseA_ReturnsUpperCaseA()
            {
                var expected = new[] {'A'};

                char[] actual = 'A'.UpTo('A');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void UpperCaseA_UpToUpperCaseZ_ReturnsUpperCaseAlphabet()
            {
                char[] expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] actual = 'A'.UpTo('Z');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void UpperCaseZ_UpToUpperCaseA_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};
                    
                char[] actual = 'Z'.UpTo('A');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void UpperCaseZ_UpToLowerCaseA_ReturnsZWithSpecialCharsUptoA()
            {
                var expected = @"Z[\]^_`a".ToCharArray();

                char[] actual = 'Z'.UpTo('a');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void UpperCaseA_UpToLowerCaseA_ReturnsAlphabethWithSpecialCharsUpToLowerCaseA()
            {
                var expected = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`a".ToCharArray();

                char[] actual = 'A'.UpTo('a');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void LowerCaseA_UpToLowerCaseZ_ReturnsLowerCaseAlphabet()
            {
                char[] expected = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

                char[] actual = 'a'.UpTo('z');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void LowerCaseA_UpToUpperCaseZ_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};

                char[] actual = 'a'.UpTo('Z');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void LowerCaseA_UpToLowerCaseA_ReturnsLowerCaseA()
            {
                var expected = new[] {'a'};

                char[] actual = 'a'.UpTo('a');

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void LowerCaseA_UpToUpperCaseA_ReturnsEmptyCharArray()
            {
                var expected = new char[]{};

                char[] actual = 'a'.UpTo('A');

                Assert.Equal(expected, actual);
            } 
            
            [Fact]
            public void Dash_UpToUnderscore_ReturnsExpectedChars()
            {
                char[] expected = @"-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_".ToCharArray();
                char[] actual = '-'.UpTo('_');

                Assert.Equal(expected, actual);
            }
        }
    }
}