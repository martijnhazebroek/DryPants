using System;
using System.Collections.Generic;
using System.Globalization;

namespace DryPants.Core
{
    public sealed class Percentage : IEquatable<Percentage>
    {
        private readonly decimal _value;
        private readonly Lazy<decimal> _decimalValue;

        public Percentage(decimal value)
        {
            _value = value;
            _decimalValue = new Lazy<decimal>(() => value / 100);
        }
        
        public decimal Of(decimal value)
        {
            return (_decimalValue.Value) * value;
        }

        public decimal IncreaseOf(decimal value)
        {
            return (1 + (_decimalValue.Value)) * value;
        }

        public decimal DecreaseOf(decimal value)
        {
            return (1 - (_decimalValue.Value)) * value;
        }

        internal static Percentage IsPercentageOf(decimal value, decimal comparedTo)
        {
            return new Percentage((value * 100) / comparedTo);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            var cast = obj as Percentage;
            return cast != null && Equals(obj);
        }

        public bool Equals(Percentage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _value == other._value;
        }

        public static bool operator ==(Percentage left, Percentage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Percentage left, Percentage right)
        {
            return !Equals(left, right);
        }

        private sealed class ValueEqualityComparer : IEqualityComparer<Percentage>
        {
            public bool Equals(Percentage x, Percentage y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x._value == y._value;
            }

            public int GetHashCode(Percentage obj)
            {
                if (obj == null)
                    throw new ArgumentNullException("obj");

                return obj._value.GetHashCode();
            }
        }

        private static readonly IEqualityComparer<Percentage> ValueComparerInstance = new ValueEqualityComparer();

        public static IEqualityComparer<Percentage> ValueComparer
        {
            get { return ValueComparerInstance; }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return (_decimalValue.Value).ToString("P", CultureInfo.InvariantCulture);
        }
    }
}
