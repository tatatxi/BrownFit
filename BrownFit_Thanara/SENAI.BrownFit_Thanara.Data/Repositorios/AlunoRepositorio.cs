using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SENAI.BrownFit_Thanara.Data.Repositorios
{
    public class AlunoRepositorio
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public List<Aluno> GetAll()
        {
            return db.Alunos.ToList();
        }

        public Aluno FindByID(Guid? id)
        {
            return db.Alunos.Find(id);
        }

        public void Delete(Aluno aluno)
        {
            db.Alunos.Remove(aluno);
            db.SaveChanges();
        }

        public void Create(Aluno aluno)
        {
            db.Alunos.Add(aluno);
            db.SaveChanges();
        }

        public void Editar(Aluno aluno)
        {
            db.Entry(aluno).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
