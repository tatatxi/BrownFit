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
    public class UsuarioRepository
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public List<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public Usuario FindById(Guid? id)
        {
            return db.Usuarios.Find(id);
        }

        public void DeleteById(Usuario usuario)
        {
            db.Usuarios.Remove(usuario);
            db.SaveChanges();

        }

        public void Create(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }

        public void Editar(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Usuario Login(string Email, string Senha)
        {
            return db.Usuarios.Where(u => u.Email.Equals(Email)
            && u.Senha == Senha).FirstOrDefault();
        }

        public string RetornarPermissoes(Guid usuarioId)
        {
            List<UsuarioPerfil> lstUsuarioPerfil = new List<UsuarioPerfil>();
            string aux = string.Empty;

            lstUsuarioPerfil = db.UsuariosPerfis.Include("Perfil").
               Where(u => u.UsuarioId == usuarioId).ToList();

            foreach (var item in lstUsuarioPerfil)
            {
                if (string.IsNullOrEmpty(aux))
                    aux = item.Perfil.Nome;
                else
                    aux += "," + item.Perfil.Nome;
            }

            return aux;
        }
    }
}
