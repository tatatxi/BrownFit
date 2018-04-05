using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Personais")]
    public class Personal
    {

        public Personal()
        {
            PersonalId = Guid.NewGuid();
            Permissao = "PERSONAL";
        }

        [Key]
        public Guid PersonalId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Column(TypeName = "int")]
        [Required]
        public string Matricula { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Senha { get; set; }

        public string Permissao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        //E um professor pode ter vários alunos
        public virtual Aluno Alunos { get; set; }

    }
}
