using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("Perfis")]
    public class Perfil
    {
        public Perfil()
        {
            PerfilId = Guid.NewGuid();
        }

        [Key]
        public Guid PerfilId { get; set; }


        [Required(ErrorMessage = "O Nome do Perfil é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Nome do Perfil deve conter no máximo 20 caracteres.")]
        [MinLength(2, ErrorMessage = "O Nome do Perfil deve conter no mínimo 2 caracteres.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome do Perfil: ")]
        public string Nome { get; set; }


        public virtual List<UsuarioPerfil> UsuariosPerfis { get; set; }

    }
}
