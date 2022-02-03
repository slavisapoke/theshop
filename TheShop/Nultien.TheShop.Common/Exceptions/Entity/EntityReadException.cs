using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Entity
{
    public class EntityReadException : EntityException
    {
        public EntityReadException(string message, string type, int id) : base(message, type, id)
        {
        }
    }
}
