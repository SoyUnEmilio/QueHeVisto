using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace QueHeVisto.Presentacion.Web.Models.Repositorios
{
    public class RepositorioSerie : IRepositorioSerie
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RepositorioSerie()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        public async Task<List<Serie>> ObtenerTodasMisSeries(string applicationUserId)
        {
            return await _applicationDbContext.Serie.Where(
                w => w.ApplicationUserId == applicationUserId).ToListAsync();
        }

        public async Task<Serie> ObtenerSeriePorId(string applicationUserId, int serieId)
        {
            return await _applicationDbContext.Serie.FirstOrDefaultAsync(
                w => w.ApplicationUserId == applicationUserId && w.SerieId == serieId);
        }

        public async Task Guardar(string applicationUserId, Serie serie)
        {
            serie.ApplicationUserId = applicationUserId;
            _applicationDbContext.Serie.Add(serie);
            await _applicationDbContext.SaveChangesAsync();

        }

        public async Task Modificar(string applicationId, Serie serie)
        {
            Serie serieAModificar = await ObtenerSeriePorId(applicationId, serie.SerieId);
            if (serieAModificar == null)
            {
                throw new ElUsuarioNoPuedeRealizarLaOperacionExcepcion();
            }

            _applicationDbContext.Entry(serie).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Borrar(string applicationId, int serieId)
        {
            Serie serieABorrar = await ObtenerSeriePorId(applicationId, serieId);
            if (serieABorrar == null)
            {
                throw new ElUsuarioNoPuedeRealizarLaOperacionExcepcion();
            }

            _applicationDbContext.Serie.Remove(serieABorrar);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}