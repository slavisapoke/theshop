using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Entity
{
    public class EntityDeleteException : EntityException
    {
        public EntityDeleteException(string message, string entityType, int id) : base(message, entityType, id)
        {
        }
    }
}
