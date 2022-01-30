namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class ExpressionEvaluatedWithFalseValueException : ValidationExceptionBase
    {
        public ExpressionEvaluatedWithFalseValueException(string context, string description = null) : base($"{context}: Validator expression evaluated with false value.", context, description)
        {
        }
    }
}
