using DryPants.Resources;
using System;
using System.Linq.Expressions;

namespace DryPants.Reflection
{
    internal static class PropertyName
    {
        internal static string For<T>(Expression<Func<T>> expression)
        {
            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(Expression expression)
        {
            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                return memberExpression.Member.Name;
            }

            throw new InvalidPropertyExpressionException();
        }
    }
}
