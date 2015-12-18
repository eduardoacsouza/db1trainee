using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rh.ConhecimentoCandidato.Dominio;
using Rh.ConhecimentoCandidato.ORM;

namespace Rh.ConhecimentoCandidato.Web.UI.Controllers
{
    public class TecnologiasController : Controller
    {
        private Context db = new Context();

        // GET: Tecnologias
        public ActionResult Index()
        {
            return View(db.Tecnologias.ToList());
        }

        // GET: Tecnologias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tecnologias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeTecnologia")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                db.Tecnologias.Add(tecnologia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tecnologia);
        }

        // GET: Tecnologias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeTecnologia")] Tecnologia tecnologia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecnologia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tecnologia);
        }

        // GET: Tecnologias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return HttpNotFound();
            }
            return View(tecnologia);
        }

        // POST: Tecnologias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tecnologia tecnologia = db.Tecnologias.Find(id);
            db.Tecnologias.Remove(tecnologia);
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
