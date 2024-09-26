using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Exceptions
{
    public abstract class RoleDataException : Exception
    {
        public RoleDataException(string message) : base(message) 
        {
        
        }
    }
}
