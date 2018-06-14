using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using SENAI.BrownFit_Thanara.Data.Repositorios;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class PerfilsController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();
        PerfilRepository perfilRepository = new PerfilRepository();

        public ActionResult Index()
        {
            return View(perfilRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = perfilRepository.FindByID(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilId,Nome")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfil.PerfilId = Guid.NewGuid();
                perfilRepository.Create(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfis.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilId,Nome")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfilRepository.Editar(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = perfilRepository.FindByID(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Perfil perfil = db.Perfis.Find(id);
            perfilRepository.Delete(perfil);
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
