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
    public class PerfilsController : Controller
    {
        private CadastroPerfilContext db = new CadastroPerfilContext();
        PerfilRepository perfilRepository = new PerfilRepository();

        // GET: Perfils
        public ActionResult Index()
        {
            return View(perfilRepository.GetAll());
        }

        // GET: Perfils/Details/5
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

        // GET: Perfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilId,Nome")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfil.PerfilId = Guid.NewGuid();
                perfilRepository.Create(perfil);
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: Perfils/Edit/5
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

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilId,Nome")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                perfilRepository.Editar(perfil);
                return RedirectToAction("Index");
            }
            return View(perfil);
        }

        // GET: Perfils/Delete/5
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

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Perfil perfil = db.Perfis.Find(id);
            perfilRepository.Delete(perfil);
            return RedirectToAction("Index");
        }

    }
}
