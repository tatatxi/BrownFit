using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class RelatoriosController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        // GET: Relatorios
        public ActionResult Index()
        {
            return View(db.Relatorios.ToList());
        }

        // GET: Relatorios/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // GET: Relatorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelatorioID")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                relatorio.RelatorioID = Guid.NewGuid();
                db.Relatorios.Add(relatorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelatorioID")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Relatorio relatorio = db.Relatorios.Find(id);
            db.Relatorios.Remove(relatorio);
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
