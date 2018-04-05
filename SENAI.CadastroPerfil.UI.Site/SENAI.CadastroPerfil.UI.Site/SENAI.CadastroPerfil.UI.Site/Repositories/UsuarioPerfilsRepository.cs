using SENAI.CadastroPerfil.UI.Site.Context;
using SENAI.CadastroPerfil.UI.Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SENAI.CadastroPerfil.UI.Site.Repositories
{
    public class UsuarioPerfilsRepository
    {
        public UsuarioPerfilsRepository()
        {

        }

        private CadastroPerfilContext db = new CadastroPerfilContext();

        public List<UsuarioPerfil> GetAll()
        {
            return db.UsuariosPerfis.ToList();
        }

        public UsuarioPerfil FindByID(Guid? id)
        {
            return db.UsuariosPerfis.Find(id);
        }

        public void DeleteById(UsuarioPerfil usuariosPerfis)
        {
            db.UsuariosPerfis.Remove(usuariosPerfis);
            db.SaveChanges();
        }

        public void Create(UsuarioPerfil usuariosPerfis)
        {
            db.UsuariosPerfis.Add(usuariosPerfis);
            db.SaveChanges();
        }

        public void Editar(UsuarioPerfil usuariosPerfis)
        {
            db.Entry(usuariosPerfis).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}