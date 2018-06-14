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
using SENAI.BrownFit_Thanara.Data.Repositorios;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class UsuariosController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();
        UsuarioRepository usuarioRepository = new UsuarioRepository();

        public ActionResult Index()
        {
            return View(usuarioRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioRepository.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha,DataNascimento")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.UsuarioId = Guid.NewGuid();
                usuarioRepository.Create(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioRepository.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,Nome,Email,Senha,DataNascimento")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //     db.Entry(usuario).State = EntityState.Modified;
                usuarioRepository.Editar(usuario);
                //return RedirectToAction("Index");
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioRepository.FindById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Usuario usuario = usuarioRepository.FindById(id);
            usuarioRepository.DeleteById(usuario);
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