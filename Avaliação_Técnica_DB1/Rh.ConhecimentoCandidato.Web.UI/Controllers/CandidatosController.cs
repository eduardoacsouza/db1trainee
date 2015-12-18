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
    public class CandidatosController : Controller
    {
        private Context db = new Context();

        // GET: Candidatos
        public ActionResult Index()
        {
            var candidatos = db.Candidatos.Include(c => c.Vagas);
            return View(candidatos.ToList());
        }

        // GET: Candidatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: Candidatos/Create
        public ActionResult Create()
        {
            //Adicionar as tecnologias ao create.
            ViewBag.Tecnologias = new MultiSelectList(db.Tecnologias, "Id", "NomeTecnologia");
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "NomeVaga");
            return View();
        }

        // POST: Candidatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Candidato candidato, int[] Tecnologias)
        {
            //Pegar as informações da outra tabela
            if (Tecnologias != null)
            {
                foreach (var Id in Tecnologias)
                {
                    Tecnologia tecnologia = db.Tecnologias.Find(Id);
                    candidato.Tecnologias.Add(tecnologia);
                }
            }
            db.Candidatos.Add(candidato);
            db.SaveChanges();
            return View("Index",db.Candidatos);
        }

        // GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "NomeVaga", candidato.VagaId);
            return View(candidato);
        }

        // POST: Candidatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeCandidato,Idade,Email,Telefone1,Telefone2,LinkedInURL,FacebookURL,VagaId,Detalhes,Pontuacao")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "NomeVaga", candidato.VagaId);
            return View(candidato);
        }

        // GET: Candidatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            db.Candidatos.Remove(candidato);
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
