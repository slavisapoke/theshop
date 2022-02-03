using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Entity
{
    public class EntityAddException : EntityException
    {
        public EntityAddException(string message, string entityType) : base(message, entityType)
        {
        }
    }
}
