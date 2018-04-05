using SENAI.CadastroPerfil.UI.Site.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SENAI.CadastroPerfil.UI.Site.Context
{
    public class CadastroPerfilContext : DbContext
    {
        public CadastroPerfilContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<UsuarioPerfil> UsuariosPerfis { get; set; }
    }
}