using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Validation
{
    public class AggregatedValidationException : ValidationExceptionBase
    {
        private readonly List<string> _errors;
        public List<string> Errors => _errors;
        public AggregatedValidationException(string context, List<string> errors) : base($"{ context}: Validation failed. Check Errors for more details.", context, null)
        {
            _errors = new List<string>(errors);
        }
    }
}
