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
    public class UsuarioPerfilsController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        // GET: UsuarioPerfils
        public ActionResult Index()
        {
            var usuariosPerfis = db.UsuariosPerfis.Include(u => u.Perfil).Include(u => u.Usuario);
            return View(usuariosPerfis.ToList());
        }

        // GET: UsuarioPerfils/Details/5
        public ActionResult Details(Guid? id)
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
            return View(usuarioPerfil);
        }

        // GET: UsuarioPerfils/Create
        public ActionResult Create()
        {
            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome");
            return View();
        }

        // POST: UsuarioPerfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioPerfilId,UsuarioId,PerfilId")] UsuarioPerfil usuarioPerfil)
        {
            if (ModelState.IsValid)
            {
                usuarioPerfil.UsuarioPerfilId = Guid.NewGuid();
                db.UsuariosPerfis.Add(usuarioPerfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome", usuarioPerfil.PerfilId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", usuarioPerfil.UsuarioId);
            return View(usuarioPerfil);
        }

        // GET: UsuarioPerfils/Edit/5
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

        // POST: UsuarioPerfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioPerfilId,UsuarioId,PerfilId")] UsuarioPerfil usuarioPerfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioPerfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfis, "PerfilId", "Nome", usuarioPerfil.PerfilId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", usuarioPerfil.UsuarioId);
            return View(usuarioPerfil);
        }

        // GET: UsuarioPerfils/Delete/5
        public ActionResult Delete(Guid? id)
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
            return View(usuarioPerfil);
        }

        // POST: UsuarioPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UsuarioPerfil usuarioPerfil = db.UsuariosPerfis.Find(id);
            db.UsuariosPerfis.Remove(usuarioPerfil);
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
