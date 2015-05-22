using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueHeVisto.Presentacion.Web.Models
{
    public class Capitulo
    {
        public int CapituloId { get; set; }
        public string Titulo { get; set; }
        public bool Visto { get; set; }
        public int TemporadaId { get; set; }
        public virtual Temporada Temporada { get; set; }
    }
}