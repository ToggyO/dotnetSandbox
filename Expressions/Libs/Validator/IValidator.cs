using System;
using System.Linq.Expressions;

namespace Expressions.Libs.Validator
{
    public interface IValidator<T> where T : class
    {
        Validator<T> AddValidation<TProp>(Expression<Func<T, TProp>> propertyExpression, Func<TProp, bool> predicate);
        bool Validate(T obj);
    }
}