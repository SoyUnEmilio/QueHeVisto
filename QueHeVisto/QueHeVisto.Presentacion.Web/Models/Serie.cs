using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueHeVisto.Presentacion.Web.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public bool Vista { get; set; }
        public bool EnEmision { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public virtual List<Temporada> Temporadas { get; set; }
    }
}