using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueHeVisto.Presentacion.Web.Models
{
    public class Temporada
    {
        public int TemporadaId { get; set; }
        public string Nombre { get; set; }
        public bool Vista { get; set; }
        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
        public virtual List<Capitulo> Capitulos { get; set; }
    }
}