using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nultien.TheShop.Common.Exceptions.Entity
{
    public class EntityException : Exception
    {
        public string EntityType { get; protected set; }
        public int? EntityID { get; protected set; }

        public EntityException(string message, string type) : base(message)
        {
            this.EntityType = type;
        }
        public EntityException(string message, string type, int id) : base(message)
        {
            this.EntityType = type;
            this.EntityID = id;
        }
    }
}
