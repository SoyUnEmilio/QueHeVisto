using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QueHeVisto.Presentacion.Web.Models;
using QueHeVisto.Presentacion.Web.Models.Repositorios;

namespace QueHeVisto.Presentacion.Web.Controllers
{
    [Authorize]
    public class SeriesController : Controller
    {
        private string ApplicationUserId {
            get
            {
                return User.Identity.GetUserId();
            }
        }

        private readonly IRepositorioSerie _repositorioSerie;

        public SeriesController()
        {
            _repositorioSerie = new RepositorioSerie();
        }

        public SeriesController(IRepositorioSerie repositorioSerie)
        {
            _repositorioSerie = repositorioSerie;
        }

        // GET: Series
        public async Task<ActionResult> Index()
        {
            return View(await _repositorioSerie.ObtenerTodasMisSeries(ApplicationUserId));
        }

        // GET: Series/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = await _repositorioSerie.ObtenerSeriePorId(ApplicationUserId, id.Value);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // GET: Series/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Nombre,Genero,Vista,EnEmision")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                await _repositorioSerie.Guardar(ApplicationUserId, serie);
                return RedirectToAction("Index");
            }

            return View(serie);
        }

        // GET: Series/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string userApplicationId = User.Identity.GetUserId();
            Serie serie = await 
                _repositorioSerie.ObtenerSeriePorId(userApplicationId, id.Value);
            if (serie == null)
            {
                return HttpNotFound();
            }

            return View(serie);
        }

        // POST: Series/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SerieId,Nombre,Genero,Vista,EnEmision")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repositorioSerie.Modificar(ApplicationUserId, serie);
                    return RedirectToAction("Index");
                }
                catch (ElUsuarioNoPuedeRealizarLaOperacionExcepcion ex)
                {
                    return HttpNotFound();
                }
            }

            return View(serie);
        }

        // GET: Series/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = await _repositorioSerie.ObtenerSeriePorId(ApplicationUserId, id.Value);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repositorioSerie.Borrar(ApplicationUserId, id);
            }
            catch (ElUsuarioNoPuedeRealizarLaOperacionExcepcion ex)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
    }
}