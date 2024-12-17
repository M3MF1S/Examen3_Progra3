using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExamenFInalProgramacion3_MatthiasPaniagua.Controllers
{
    public class SalariosController : Controller
    {
        private ExamenFinalProgra3Entities2 db = new ExamenFinalProgra3Entities2();

        // GET: Salarios
        public ActionResult Index()
        {
            var salarios = db.Salarios.Include(s => s.Empleados);
            return View(salarios.ToList());
        }

        // GET: Salarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarios salarios = db.Salarios.Find(id);
            if (salarios == null)
            {
                return HttpNotFound();
            }
            return View(salarios);
        }

        // GET: Salarios/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "pnombre");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalariosId,EmpleadoId,salario")] Salarios salarios)
        {
            if (ModelState.IsValid)
            {
                db.Salarios.Add(salarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "pnombre", salarios.EmpleadoId);
            return View(salarios);
        }

        // GET: Salarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarios salarios = db.Salarios.Find(id);
            if (salarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "pnombre", salarios.EmpleadoId);
            return View(salarios);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalariosId,EmpleadoId,salario")] Salarios salarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "pnombre", salarios.EmpleadoId);
            return View(salarios);
        }

        // GET: Salarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salarios salarios = db.Salarios.Find(id);
            if (salarios == null)
            {
                return HttpNotFound();
            }
            return View(salarios);
        }

        // POST: Salarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salarios salarios = db.Salarios.Find(id);
            db.Salarios.Remove(salarios);
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
