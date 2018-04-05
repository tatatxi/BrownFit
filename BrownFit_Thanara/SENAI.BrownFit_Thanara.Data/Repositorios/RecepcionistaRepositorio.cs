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
    public class RecepcionistaRepositorio
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public Recepcionista EfetuarLogin(string matricula, string senha)
        {
            return db.Recepcionistas.Where(r => r.Matricula.Equals(matricula) && r.Senha.Equals(senha)).FirstOrDefault();
        }

        public List<Recepcionista> GetAll()
        {
            return db.Recepcionistas.ToList();
        }

        public Recepcionista FindByID(Guid? id)
        {
            return db.Recepcionistas.Find(id);
        }

        public void Delete(Recepcionista recepcionista)
        {
            db.Recepcionistas.Remove(recepcionista);
            db.SaveChanges();
        }

        public void Create(Recepcionista recepcionista)
        {
            db.Recepcionistas.Add(recepcionista);
            db.SaveChanges();
        }

        public void Editar(Recepcionista recepcionista)
        {
            db.Entry(recepcionista).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
