namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class ValidatorImplementationException : ValidationExceptionBase
    {
        public ValidatorImplementationException(string message, string context, string description) : base(message, context, description)
        {
        }
    }
}
