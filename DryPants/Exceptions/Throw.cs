using System;
using System.Linq.Expressions;

namespace DryPants.Exceptions
{
    public static class Throw
    {
        #region [======== Null Checks ========]

        /// <summary>
        /// Throws an Exception if the Expression points to a property thats null.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression that points to a property to be checked for a null value.</param>
        public static void IfArgumentNull<TProperty>(Expression<Func<TProperty>> expression)
        {
            if (expression == null) throw new ArgumentNullException("expression");

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException(Strings.ExpressionNotPropertyOrArgumentName);

            IfArgumentNull(memberExpression.Member.Name, expression.Compile()());
        }

        /// <summary>
        /// Throws an exception if the given argument is null.
        /// </summary>
        /// <param name="paramName">The name of the argument.</param>
        /// <param name="argument">The argument to check.</param>
        /// <exception cref="ArgumentNullException">The type of Exception thrown.</exception>
        public static void IfArgumentNull(string paramName, object argument)
        {
            if (paramName == null)
                throw new ArgumentNullException("paramName");
            if (argument == null)
                throw new ArgumentNullException(paramName);
        }

        #endregion

        #region [======== String Checks ========]
        
        /// <summary>
        /// Throws an exception if the given argument is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="paramName">The name of the argument.</param>
        /// <param name="argument">The argument to check.</param>
        /// <exception cref="ArgumentNullException">The type of Exception thrown.</exception>
        public static void IfArgumentNullOrWhiteSpace(string paramName, string argument)
        {
            IfArgumentNull(paramName, argument);
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentNullException(paramName);
        }

        #endregion
    }
}