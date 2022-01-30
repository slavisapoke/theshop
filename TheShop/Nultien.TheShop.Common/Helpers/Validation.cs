using Nultien.TheShop.Common.Exceptions.Validation;
using System;

namespace Nultien.TheShop.Common.Helpers
{
    /// <summary>
    /// Example Validation helper. 
    /// </summary>
    public class Validation
    {
        private string _callerContext;

        private Validation() { }

        public static Validation Create(string context = null)
        {

            var date = DateTime.Now;
            if (string.IsNullOrEmpty(context))
            {
                var callerMethod = (new System.Diagnostics.StackTrace()).GetFrame(1).GetMethod();

                return new Validation
                {
                    _callerContext = $"{callerMethod.DeclaringType.Name}.{callerMethod.Name}"
                };
            }


            return new Validation
            {
                _callerContext = context
            };
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
                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new NullOrDefaultException(_callerContext);
                }

                throw new NullOrDefaultException(_callerContext, description);
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
                if (string.IsNullOrWhiteSpace(description))
                {
                    throw new NullOrDefaultException(_callerContext);
                }

                throw new NullOrDefaultException(_callerContext, description);
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
                throw new NotTrueException(_callerContext, description);
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
            if(validatorFunc == null)
            {
                throw new ValidatorImplementationException("Validator function is null", _callerContext, description);
            }

            if (true != validatorFunc())
            {
                throw new ExpressionEvaluatedWithFalseValueException(_callerContext, description);
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
                throw new ValidatorImplementationException("Parameter greaterThanValue is null", _callerContext, description);
            }

            if (!value.HasValue)
            {
                throw new NullOrDefaultException(_callerContext, description);
            }

            if(value.Value <= greaterThanValue.Value)
            {
                throw new NumberNotInRangeException(_callerContext, description);
            }

            return this;
        }
    }
}
