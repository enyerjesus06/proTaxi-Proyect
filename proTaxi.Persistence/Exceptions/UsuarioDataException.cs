using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Exceptions
{
    public abstract class UsuarioDataException : Exception
    {
        public UsuarioDataException(string message) : base(message)
        {

        }
    }
}
