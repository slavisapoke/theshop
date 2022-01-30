namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class NullOrDefaultException : ValidationExceptionBase
    {
        public NullOrDefaultException(string context, string description = null) : base($"{context}: Given value is null or default.", context, description)
        {
        }
    }
}
