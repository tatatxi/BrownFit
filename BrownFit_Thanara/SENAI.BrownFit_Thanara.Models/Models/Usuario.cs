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
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            UsuarioId = Guid.NewGuid();
        }

        [Key]
        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "O Nome do usuário é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Nome do usuário deve conter no máximo 50 caracteres.")]
        [MinLength(2, ErrorMessage = "O Nome do usuário deve conter no mínimo 2 caracteres.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome do usuário: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O E-mail do usuário é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O E-mail do usuário deve conter no máximo 50 caracteres.")]
        [MinLength(6, ErrorMessage = "O E-mail do usuário deve conter no mínimo 6 caracteres.")]
        [Column(TypeName = "varchar")]
        [DisplayName("E-mail do usuário: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha do usuário é obrigatória.")]
        [MaxLength(12, ErrorMessage = "A Senha do usuário deve conter no máximo 12 caracteres.")]
        [MinLength(4, ErrorMessage = "A Senha do usuário deve conter no mínimo 4 caracteres.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Senha do usuário: ")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento: ")]
        public DateTime DataNascimento { get; set; }

        public virtual List<UsuarioPerfil> UsuariosPerfis { get; set; }
    }
}
