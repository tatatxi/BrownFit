using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Data.Repositorios
{
    public class PersonalRepositorio
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public Personal EfetuarLogin(string matricula, string senha)
        {
            return db.Personais.Where(c => c.Matricula.Equals(matricula) && c.Senha.Equals(senha)).FirstOrDefault();
        }

        public List<Personal> GetAll()
        {
            return db.Personais.ToList();
        }

        public Personal FindByID(Guid? id)
        {
            return db.Personais.Find(id);
        }

        public void Delete(Personal personal)
        {
            db.Personais.Remove(personal);
            db.SaveChanges();
        }

        public void Create(Personal personal)
        {
            db.Personais.Add(personal);
            db.SaveChanges();
        }

        public void Editar(Personal personal)
        {
            db.Entry(personal).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
