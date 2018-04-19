using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Recepcionistas")]
    public class Recepcionista
    {
        public Recepcionista()
        {
            RecepcionistaID = Guid.NewGuid();
            Permissao = "RECEPCIONISTA";
        }

        [Key]
        public Guid RecepcionistaID { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Matricula { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Senha { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome: ")]
        public string Nome { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public Guid AlunoId { get; set; }

        //E uma recepcionista cadastra vários alunos
        public virtual Aluno Aluno { get; set; }

        public string Permissao { get; set; }
    }
}
