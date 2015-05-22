using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using QueHeVisto.Presentacion.Web.Models;

namespace QueHeVisto.Presentacion.Web.Controllers
{
    [Authorize]
    public class SeriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Series
        public async Task<ActionResult> Index()
        {
            var serie = db.Serie;
            return View(await serie.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = await db.Serie.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "SerieId,Nombre,Genero,Vista,EnEmision")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                serie.ApplicationUserId = User.Identity.GetUserId();
                db.Serie.Add(serie);
                await db.SaveChangesAsync();
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
            Serie serie = await db.Serie.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "SerieId,Nombre,Genero,Vista,EnEmision,ApplicationUserId")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serie).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
            Serie serie = await db.Serie.FindAsync(id);
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
            Serie serie = await db.Serie.FindAsync(id);
            db.Serie.Remove(serie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
