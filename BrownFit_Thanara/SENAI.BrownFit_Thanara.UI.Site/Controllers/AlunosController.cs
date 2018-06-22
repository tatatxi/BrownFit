using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using SENAI.BrownFit_Thanara.Util.Extensoes;

namespace SENAI.BrownFit_Thanara.UI.Site.Controllers
{
    //[CustomAuthorize(Roles = "Admin, Personal, Recepcionista")]
    public class AlunosController : Controller
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public ActionResult Index()
        {
            return View(db.Alunos.Where(a => !a.Excluido).ToList());
        }

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoID,Nome,Sobrenome,CPF,Email,DataNascimento,DataCadastro,Ativo,Excluido,Permissao,Peso,Altura,MassaMagra,TipoTreino,TempoTreino,Sugestao")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (!aluno.CPF.ValidarCPF())
                {
                    ViewBag.MsgErro = "CPF inválido!";
                    return View("Create");
                }

                aluno.AlunoID = Guid.NewGuid();
                aluno.DataCadastro = DateTime.Now;
                db.Alunos.Add(aluno);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(aluno);
        }

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


        //arrumar
        //public ActionResult Buscar([Bind(Include = "Nome")] Aluno? Nome)
        //{
        //    if (Nome.HasValue)
        //    {
        //        return View("Index", db.Alunos.Where(o => DbFunctions.(o.Nome) == DbFunctions.(aluno.Value).ToList()));
        //    }
        //    return View("Index", db.Alunos.ToList());
        //}

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Aluno aluno = db.Alunos.Find(id);
            aluno.Excluido = true;
            //db.Alunos.Remove(aluno);
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
