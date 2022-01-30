using System;

namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class ValidationExceptionBase  :Exception
    {
        public string Context { get; private set; }
        public string ContextDescription { get; private set; }
        public ValidationExceptionBase(string message, string context, string description) :base($"{message}{Environment.NewLine}Additional Info: {description}")  {
            this.Context = context;
            this.ContextDescription = description;
        }
    }
}
