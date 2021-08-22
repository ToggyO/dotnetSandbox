using System;
using System.Reflection;

namespace Expressions.Libs.Validator
{
    public interface IValidationRule<TProp> : IValidationRule
    {
        new Func<TProp, bool> Predicate { get; set; }
    }

    public interface IValidationRule
    {
        PropertyInfo Property { get; set; }
        Func<object, bool> Predicate { get; set; }
        bool Validate(object obj);
    }
}