using SENAI.CadastroPerfil.UI.Site.Context;
using SENAI.CadastroPerfil.UI.Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SENAI.CadastroPerfil.UI.Site.Repositories
{
    public class PerfilRepository
    {
        private CadastroPerfilContext db = new CadastroPerfilContext();

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