using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Data.Repositorios
{
    public class UsuarioPerfilsRepository
    {
        public UsuarioPerfilsRepository()
        {

        }

        private Brown_ThanaraContext db = new Brown_ThanaraContext();

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
