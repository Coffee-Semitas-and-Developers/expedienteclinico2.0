using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedEvolution.Models;

namespace MedEvolution.Controllers
{
    public class DireccionesController : Controller
    {
        private MedEvolutionDbContext db = new MedEvolutionDbContext();

        // GET: Direcciones
        public ActionResult Index()
        {
            var direcciones = db.Direcciones.Include(d => d.Departamento).Include(d => d.Municipio);
            return View(direcciones.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            if (ColoniaID == null || Pasaje_CalleID == null || CasaID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direcciones.Find(ColoniaID, Pasaje_CalleID, CasaID);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            ViewBag.codigoDepartamento = new SelectList(db.Departamentos, "CodigoDepartamento", "NombreDep");
            ViewBag.codigoMunicipio = new SelectList(db.Municipios, "CodigoMunicipio", "NombreMun");
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Colonia,Pasaje_calle,Casa,Detalle,codigoDepartamento,codigoMunicipio")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoDepartamento = new SelectList(db.Departamentos, "CodigoDepartamento", "NombreDep", direccion.codigoDepartamento);
            ViewBag.codigoMunicipio = new SelectList(db.Municipios, "CodigoMunicipio", "NombreMun", direccion.codigoMunicipio);
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            if (ColoniaID == null || Pasaje_CalleID == null || CasaID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direcciones.Find(ColoniaID,Pasaje_CalleID,CasaID);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoDepartamento = new SelectList(db.Departamentos, "CodigoDepartamento", "NombreDep", direccion.codigoDepartamento);
            ViewBag.codigoMunicipio = new SelectList(db.Municipios, "CodigoMunicipio", "NombreMun", direccion.codigoMunicipio);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Colonia,Pasaje_calle,Casa,Detalle,codigoDepartamento,codigoMunicipio")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoDepartamento = new SelectList(db.Departamentos, "CodigoDepartamento", "NombreDep", direccion.codigoDepartamento);
            ViewBag.codigoMunicipio = new SelectList(db.Municipios, "CodigoMunicipio", "NombreMun", direccion.codigoMunicipio);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            if (ColoniaID == null || Pasaje_CalleID == null || CasaID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direcciones.Find(ColoniaID, Pasaje_CalleID, CasaID);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string ColoniaID, string Pasaje_CalleID, string CasaID)
        {
            Direccion direccion = db.Direcciones.Find(ColoniaID, Pasaje_CalleID, CasaID);
            db.Direcciones.Remove(direccion);
            db.SaveChanges();
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
