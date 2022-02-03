using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Entity
{
    public class EntityUpdateException : EntityException
    {
        public EntityUpdateException(string message, string type, int id) : base(message, type, id)
        {
        }
    }
}
