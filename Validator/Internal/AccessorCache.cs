using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Validator.Internal
{
    /// <summary>
    /// Member accessor cache.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class AccessorCache<T>
    {
        private static readonly ConcurrentDictionary<Key, Delegate> _cache = new();

        /// <summary>
        /// Gets an accessor func based on an expression
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="member">The member represented by the expression</param>
        /// <param name="expression"></param>
        /// <param name="bypassCache"></param>
        /// <param name="cachePrefix">Cache prefix</param>
        /// <returns>Accessor func</returns>
        public static Func<T, TProperty> GetCachedAccessor<TProperty>(
            MemberInfo member, Expression<Func<T, TProperty>> expression, string cachePrefix = null)
        {
            if (member is null)
                return expression.Compile();

            var key = new Key(member, expression, cachePrefix);
            return (Func<T, TProperty>) _cache.GetOrAdd(key, k => expression.Compile());
        }

        private class Key
        {
            private readonly MemberInfo _memberInfo;
            private readonly string _expressionDebugView;

            public Key(MemberInfo memberInfo, Expression expression, string cachePrefix)
            {
                _memberInfo = memberInfo;
                _expressionDebugView =
                    cachePrefix is null ? expression.ToString() : cachePrefix + expression;
            }

            protected bool Equals(Key other)
                => Equals(_memberInfo, other._memberInfo) &&
                   string.Equals(_expressionDebugView, other._expressionDebugView);

            public override bool Equals(object? obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Key) obj);
            }

            public override int GetHashCode() => HashCode.Combine(_memberInfo, _expressionDebugView);
        }
    }
}