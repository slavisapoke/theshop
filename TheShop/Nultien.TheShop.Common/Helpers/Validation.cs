using Nultien.TheShop.Common.Exceptions.Validation;
using System;
using System.Collections.Generic;

namespace Nultien.TheShop.Common.Helpers
{
    /// <summary>
    /// Example Validation helper. 
    /// </summary>
    public class Validation
    {
        private string _callerContext;
        private bool _throwOnExecute;
        private List<string> _errors = new List<string>();

        private Validation() { }

        /// <summary>
        /// Creates validation context
        /// </summary>
        /// <param name="context">Validation context, or if null, context will be executing method</param>
        /// <param name="collectAndThrow">
        /// Should validatoin errors be collected passed to a single exception when method Execute is invoked,
        /// or if an exception be thrown immediately on first validation method call
        /// </param>
        /// <returns></returns>
        public static Validation Create(bool collectAndThrow = true, string context = null)
        {  
            if (string.IsNullOrEmpty(context))
            {
                var callerMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod();

                return new Validation
                { 
                    _throwOnExecute = collectAndThrow,
                    _callerContext = $"{callerMethod.DeclaringType.Name}.{callerMethod.Name}"
                };
            }

            return new Validation
            {
                _throwOnExecute = collectAndThrow,
                _callerContext = context
            };
        }

        public void Execute()
        {
            if(_errors.Count > 0)
            {
                throw new AggregatedValidationException(_callerContext, _errors);
            }
        }

        /// <summary>
        /// Throws exception if the given parameter has null or default value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="act"></param>
        /// <param name="description"></param>
        /// <exception cref="NullOrDefaultException"></exception>
        public Validation NotNullOrDefault<T>(T value, string description = null)
        {
            if (value == null || value.Equals(default(T)))
            {
                if (!_throwOnExecute)
                {
                    throw new NullOrDefaultException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Given value is null or default. Description: {description}");
            }

            return this;
        }

        /// <summary>
        /// Throws exception if the given parameter has null or empty string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="NullOrDefaultException"></exception>
        public Validation NotNullOrEmpty<T>(T value, string description = null)
        {
            if (value == null || value.Equals(default(T)) || string.IsNullOrEmpty(value.ToString()))
            {
                if (!_throwOnExecute)
                {
                    throw new NullOrDefaultException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Given value is null or default. Description: {description}");
            }

            return this;
        }

        /// <summary>
        /// Throws exception if the given value is not True
        /// </summary>
        /// <param name="value"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="NotTrueException"></exception>
        public Validation IsTrue(bool? value, string description = null)
        {
            if (true != value)
            {
                if (!_throwOnExecute)
                {
                    throw new NotTrueException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Given value is not true. Description: {description}");
            }

            return this;
        }

        /// <summary>
        /// Throws exception if function evaluation gives result different than True
        /// </summary>
        /// <param name="validatorFunc"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="ValidatorImplementationException"></exception>
        /// <exception cref="ExpressionEvaluatedWithFalseValueException"></exception>
        public Validation IsTrue(Func<bool?> validatorFunc, string description = null)
        {
            if(validatorFunc == null)  //immediate throw, implementation error
            {
                throw new ValidatorImplementationException("Validator function is null", _callerContext, description);
            }

            if (true != validatorFunc())
            {
                if (!_throwOnExecute)
                {
                    throw new ExpressionEvaluatedWithFalseValueException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Validator expression evaluated with false value. Description: {description}");
            }

            return this;
        }

        /// <summary>
        /// Throws exception if the given value is not greater than the given greaterThanValue number
        /// </summary>
        /// <param name="value"></param>
        /// <param name="greaterThanValue"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        /// <exception cref="ValidatorImplementationException"></exception>
        /// <exception cref="NullOrDefaultException"></exception>
        /// <exception cref="NumberNotInRangeException"></exception>
        public Validation IsGreaterThan(int? value, int? greaterThanValue, string description = null)
        {
            if (!greaterThanValue.HasValue)
            {
                if (!_throwOnExecute)
                {
                    throw new ValidatorImplementationException("Parameter greaterThanValue is null", _callerContext, description);
                }
                _errors.Add($"{_callerContext}: Parameter greaterThanValue is null. Description: {description}");
            }

            if (!value.HasValue)
            {
                if (!_throwOnExecute)
                {
                    throw new NullOrDefaultException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Given value is null or default. Description: {description}");
            }

            if(value.HasValue && greaterThanValue.HasValue && value.Value <= greaterThanValue.Value)
            {
                if (!_throwOnExecute)
                {
                    throw new NumberNotInRangeException(_callerContext, description);
                }
                _errors.Add($"{_callerContext}: Given value is not greater than {value.Value}. Description: {description}");
            }

            return this;
        }
    }
}
