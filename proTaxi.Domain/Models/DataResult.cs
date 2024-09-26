using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Domain.Models
{
    public class DataResult<TData>
    {
        public DataResult ()
        {
            this.Success = true;
        }
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje asociado con la operación (por ejemplo, mensajes de error o éxito).
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Resultado de la operación, que puede ser cualquier tipo de dato (especificado por TData).
        /// </summary>
        public TData? Result { get; set; }
    }
}
