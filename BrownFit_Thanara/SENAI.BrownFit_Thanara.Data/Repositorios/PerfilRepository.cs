using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SENAI.BrownFit_Thanara.Data.Repositorios
{
    public class PerfilRepository
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public List<Perfil> GetAll()
        {
            return db.Perfis.ToList();
        }

        public Perfil FindByID(Guid? id)
        {
            return db.Perfis.Find(id);
        }

        public void Delete(Perfil perfil)
        {
            db.Perfis.Remove(perfil);
            db.SaveChanges();
        }

        public void Create(Perfil perfil)
        {
            db.Perfis.Add(perfil);
            db.SaveChanges();
        }

        public void Editar(Perfil perfil)
        {
            db.Entry(perfil).State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
