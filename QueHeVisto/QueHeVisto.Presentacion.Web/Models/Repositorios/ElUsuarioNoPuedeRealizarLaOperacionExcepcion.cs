using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QueHeVisto.Presentacion.Web.Models.Repositorios
{
    public class ElUsuarioNoPuedeRealizarLaOperacionExcepcion : Exception
    {
        public ElUsuarioNoPuedeRealizarLaOperacionExcepcion()
            : base() { }

        public ElUsuarioNoPuedeRealizarLaOperacionExcepcion(string message)
            : base(message) { }

        public ElUsuarioNoPuedeRealizarLaOperacionExcepcion(string message, Exception inner)
            : base(message, inner) { }

        public ElUsuarioNoPuedeRealizarLaOperacionExcepcion(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
