using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Validator.Internal
{
    /// <summary>
    /// Useful extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
		/// Gets a MemberInfo from a member expression.
		/// </summary>
        public static MemberInfo GetMember<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            var memberExp = expression.Body as MemberExpression;

            if (memberExp is null)
                return null;

            return memberExp.Member;
        }
    }
}
