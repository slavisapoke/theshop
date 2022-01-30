namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class NumberNotInRangeException : ValidationExceptionBase
    {
        public NumberNotInRangeException(string context, string description = null) : base($"{context}: Given value is not in the defined range.", context, description)
        {
        }
    }
}
