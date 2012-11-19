using System;
using System.Linq;

namespace DryPants.Extensions
{
    public static class CharExtensions
    {
        public static char[] UpTo(this char source, char limit)
        {
            return ((int)source).InternalUpTo(limit)
                                .Select(Convert.ToChar)
                                .ToArray();
        }

        public static int ToAlphabetIndex(this char character)
        {
            return Char.IsLetter(character) ? Char.ToUpperInvariant(character) - 'A' : -1;
        }
    }
}
