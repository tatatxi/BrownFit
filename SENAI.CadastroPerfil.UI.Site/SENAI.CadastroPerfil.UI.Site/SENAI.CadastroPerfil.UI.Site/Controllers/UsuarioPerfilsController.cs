using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SENAI.CadastroPerfil.UI.Site.Context;
using SENAI.CadastroPerfil.UI.Site.Models;
using SENAI.CadastroPerfil.UI.Site.Repositories;

namespace SENAI.CadastroPerfil.UI.Site.Controllers
{
    [Authorize(Roles = "random")]
    public class UsuarioPerfilsController : Controller
    {
        private CadastroPerfilContext db = new CadastroPerfilContext();
        UsuarioPerfilsRepository usuarioPerfilsRepository = new UsuarioPerfilsRepository();

        // GET: UsuarioPerfils

        public ActionResult Index()
        {
            
            return View(usuarioPerfilsRepository.GetAll());
        }

        // GET: UsuarioPerfils/Details/5
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
                usuarioPerfilsRepository.Create(usuarioPerfil);
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
            UsuarioPerfil usuarioPerfil = usuarioPerfilsRepository.FindByID(id);
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
                usuarioPerfilsRepository.Editar(usuarioPerfil);
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
            UsuarioPerfil usuarioPerfil = usuarioPerfilsRepository.FindByID(id); ;
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
            usuarioPerfilsRepository.DeleteById(usuarioPerfil);
            return RedirectToAction("Index");
        }

    }
}
