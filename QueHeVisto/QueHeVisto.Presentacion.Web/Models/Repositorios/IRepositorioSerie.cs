using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueHeVisto.Presentacion.Web.Models.Repositorios
{
    public interface IRepositorioSerie : IDisposable
    {
        Task<List<Serie>> ObtenerTodasMisSeries(string applicationUserId);
        Task<Serie> ObtenerSeriePorId(string applicationUserId, int serieId);
        Task Guardar(string applicationUserId, Serie serie);
        Task Modificar(string applicationUserId, Serie serie);
        Task Borrar(string applicationUserId, int id);
    }
}
