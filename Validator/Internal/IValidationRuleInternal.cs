using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator.Internal
{
    /// <summary>
    /// Defines an internal rule associated with a property.
    /// </summary>
    /// <typeparam name="T">Type of instance to validate.</typeparam>
    /// <typeparam name="TProperty">Type of instance member.</typeparam>
    internal interface IValidationRuleInternal<T, TProperty> : IValidationRuleInternal<T>, IValidationRule<T, TProperty>
    {
        /// <summary>
        /// Collection of <see cref="RuleComponent{T, TProperty}"/>
        /// </summary>
        new List<IRuleComponent<T, TProperty>> Components { get; }
    }

    /// <summary>
    /// Defines an internal rule associated with a property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IValidationRuleInternal<T> : IValidationRule<T>
    {

        /// <summary>
        /// Validate instance by rule.
        /// </summary>
        /// <param name="context">Instance of <see cref="ValidationContext{T}"/></param>
        /// <returns>Boolean validation result.</returns>
        void Validate(ValidationContext<T> context);
    }
}
