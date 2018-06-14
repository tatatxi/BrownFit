using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    //[CustomAuthorize(Roles = "Admin, Personal")]
    public class AgendaController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        // GET: Agenda
        public ActionResult Index()
        {
            //var lst = db.Agendas
            //    .Join(
            //        db.Aulas,
            //        agenda => agenda.Aula.AulaID,
            //        aula => aula.AulaID,
            //        (agenda, aula) => new { agenda }
            //    ).ToList();
            return View(db.Agendas.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.Aulas = db.Aulas.ToList();
            ViewBag.Professores = db.Usuarios.Where(p => p.UsuariosPerfis.Any(up => up.Perfil.Nome == "Personal")).ToList();
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgendaID,DataAula,Descricao")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                agenda.AgendaID = Guid.NewGuid();
                db.Agendas.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgendaID,DataAula,Descricao")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Agenda agenda = db.Agendas.Find(id);
            db.Agendas.Remove(agenda);
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

        public ActionResult Buscar([Bind(Include = "DataAula")] DateTime? DataAula)
        {
            if (DataAula.HasValue)
            {
                return View("Index", db.Agendas.Where(o => DbFunctions.TruncateTime(o.DataAula) == DbFunctions.TruncateTime(DataAula.Value)).ToList());
            }
            return View("Index", db.Agendas.ToList());
        }
    }
}
