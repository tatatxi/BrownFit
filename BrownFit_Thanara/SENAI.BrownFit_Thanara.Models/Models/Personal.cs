using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Personais")]
    public class Personal
    {

        public Personal()
        {
            PersonalID = Guid.NewGuid();
            Permissao = "PERSONAL";
        }

        [Key]
        public Guid PersonalID { get; set; }

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

        public string Permissao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        public Guid AlunoID { get; set; }

        //E um professor pode ter vários alunos
        [ForeignKey("AlunoID")]
        public virtual Aluno Aluno { get; set; }

    }
}
