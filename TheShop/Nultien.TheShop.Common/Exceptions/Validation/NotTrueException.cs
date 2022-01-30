namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class NotTrueException : ValidationExceptionBase
    {
        public NotTrueException(string context, string description = null) : base($"{context}: Given value is not true.", context, description)
        {
        }
    }
}
