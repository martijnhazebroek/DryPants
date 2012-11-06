using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace DryPants.Lib
{
    /// <remarks>
    /// Thanks to Henri Wiechers' Henri Formatter (http://haacked.com/archive/2009/01/14/named-formats-redux.aspx)
    /// </remarks>
    internal static class HenriFormatter
    {
        private static string OutExpression(object source, string expression)
        {
            string format = "";

            int colonIndex = expression.IndexOf(':');
            if (colonIndex > 0)
            {
                format = expression.Substring(colonIndex + 1);
                expression = expression.Substring(0, colonIndex);
            }

            try
            {
                if (String.IsNullOrEmpty(format))
                {
                    return (DataBinder.Eval(source, expression) ?? "").ToString();
                }
                return DataBinder.Eval(source, expression, "{0:" + format + "}");
            }
            catch (HttpException)
            {
                throw new FormatException();
            }
        }

        public static string HenriFormat(this string format, object source)
        {
            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            var result = new StringBuilder(format.Length * 2);

            using (var reader = new StringReader(format))
            {
                var expression = new StringBuilder();

                var state = State.OutsideExpression;
                do
                {
                    int @char;
                    switch (state)
                    {
                        case State.OutsideExpression:
                            @char = reader.Read();
                            switch (@char)
                            {
                                case -1:
                                    state = State.End;
                                    break;
                                case '{':
                                    state = State.OnOpenBracket;
                                    break;
                                case '}':
                                    state = State.OnCloseBracket;
                                    break;
                                default:
                                    result.Append((char)@char);
                                    break;
                            }
                            break;
                        case State.OnOpenBracket:
                            @char = reader.Read();
                            switch (@char)
                            {
                                case -1:
                                    throw new FormatException();
                                case '{':
                                    result.Append('{');
                                    state = State.OutsideExpression;
                                    break;
                                default:
                                    expression.Append((char)@char);
                                    state = State.InsideExpression;
                                    break;
                            }
                            break;
                        case State.InsideExpression:
                            @char = reader.Read();
                            switch (@char)
                            {
                                case -1:
                                    throw new FormatException();
                                case '}':
                                    result.Append(OutExpression(source, expression.ToString()));
                                    expression.Length = 0;
                                    state = State.OutsideExpression;
                                    break;
                                default:
                                    expression.Append((char)@char);
                                    break;
                            }
                            break;
                        case State.OnCloseBracket:
                            @char = reader.Read();
                            switch (@char)
                            {
                                case '}':
                                    result.Append('}');
                                    state = State.OutsideExpression;
                                    break;
                                default:
                                    throw new FormatException();
                            }
                            break;
                        default:
                            throw new InvalidOperationException("Invalid state.");
                    }
                } while (state != State.End);
            }

            return result.ToString();
        }

        private enum State
        {
            OutsideExpression,
            OnOpenBracket,
            InsideExpression,
            OnCloseBracket,
            End
        }
    }
}