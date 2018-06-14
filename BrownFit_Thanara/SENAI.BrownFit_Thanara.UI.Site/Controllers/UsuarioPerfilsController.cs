using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Data.Repositorios;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class UsuarioPerfilsController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();
        UsuarioPerfilsRepository usuarioPerfilsRepository = new UsuarioPerfilsRepository();

        public ActionResult Index()
        {
            return View(usuarioPerfilsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPerfil usuarioPerfil = usuarioPerfilsRepository.FindByID(id);
            if (usuarioPerfil == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPerfil);
        }

        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioPerfilId,UsuarioId,PerfilId")] UsuarioPerfil usuarioPerfil)
        {
            if (ModelState.IsValid)
            {
                usuarioPerfil.UsuarioPerfilId = Guid.NewGuid();
                usuarioPerfilsRepository.Create(usuarioPerfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome", usuarioPerfil.PerfilId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", usuarioPerfil.UsuarioId);
            return View(usuarioPerfil);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPerfil usuarioPerfil = db.UsuariosPerfis.Find(id);
            if (usuarioPerfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome", usuarioPerfil.PerfilId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", usuarioPerfil.UsuarioId);
            return View(usuarioPerfil);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioPerfilId,UsuarioId,PerfilId")] UsuarioPerfil usuarioPerfil)
        {
            if (ModelState.IsValid)
            {
                usuarioPerfilsRepository.Editar(usuarioPerfil);
                return RedirectToAction("Index");
                //  db.Entry(usuarioPerfil).State = EntityState.Modified;
                // db.SaveChanges();
                //     return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome", usuarioPerfil.PerfilId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", usuarioPerfil.UsuarioId);
            return View(usuarioPerfil);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioPerfil usuarioPerfil = usuarioPerfilsRepository.FindByID(id); ;
            if (usuarioPerfil == null)
            {
                return HttpNotFound();
            }
            return View(usuarioPerfil);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UsuarioPerfil usuarioPerfil = db.UsuariosPerfis.Find(id);
            usuarioPerfilsRepository.DeleteById(usuarioPerfil);
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
