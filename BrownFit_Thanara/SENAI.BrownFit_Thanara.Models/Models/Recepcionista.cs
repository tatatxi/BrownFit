using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Recepcionistas")]
    public class Recepcionista
    {
        public Recepcionista()
        {
            RecepcionistaId = Guid.NewGuid();
            Permissao = "RECEPCIONISTA";
        }

        [Key]
        public Guid RecepcionistaId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Column(TypeName = "int")]
        [Required]
        public string Matricula { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        //E uma recepcionista cadastra vários alunos
        public virtual Aluno Alunos { get; set; }

        public string Permissao { get; set; }
    }
}
