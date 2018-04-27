using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("UsuariosPerfis")]
    public class UsuarioPerfil
    {
        public UsuarioPerfil()
        {
            UsuarioPerfilId = Guid.NewGuid();
        }

        [Key]
        public Guid UsuarioPerfilId { get; set; }

        public Guid UsuarioId { get; set; }
        public Guid PerfilId { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
