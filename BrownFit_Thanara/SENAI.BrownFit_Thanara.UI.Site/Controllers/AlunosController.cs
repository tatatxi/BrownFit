using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    public class AlunosController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        // GET: Alunos
        public ActionResult Index()
        {
            return View(db.Alunos.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoID,Nome,Sobrenome,CPF,Email,DataNascimento,DataCadastro,Ativo,Excluido,Permissao,Peso,Altura,MassaMagra,TipoTreino,TempoTreino,Sugestao")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                aluno.AlunoID = Guid.NewGuid();
                db.Alunos.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoID,Nome,Sobrenome,CPF,Email,DataNascimento,DataCadastro,Ativo,Excluido,Permissao,Peso,Altura,MassaMagra,TipoTreino,TempoTreino,Sugestao")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
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
