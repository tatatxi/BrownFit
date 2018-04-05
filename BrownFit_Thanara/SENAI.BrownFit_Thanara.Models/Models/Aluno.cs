using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SENAI.BrownFit_Thanara.Models.Models.Enderecos;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    public class Aluno
    {
        public Aluno()
        {
            AlunoId = Guid.NewGuid();
            Permissao = "Aluno";
        }

        [Key]
        [Column("Id")]
        public Guid AlunoId { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "O Nome do Aluno é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O Nome do Perfil deve conter no máximo 20 caracteres.")]
        [MinLength(2, ErrorMessage = "O Nome do Perfil deve conter no mínimo 2 caracteres.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome do Aluno: ")]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        [Column(TypeName = "varchar")]
        [DisplayName("Sobrenome do Aluno: ")]
        public string Sobrenome { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Required]
        public string CPF { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required]
        [DisplayName("E-mail do Aluno: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Data de Nascimento: ")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro: ")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [DisplayName("Situação: ")]
        public bool Ativo { get; set; }

        [Required]
        public bool Excluido { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Permissao { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Required]
        public string Peso { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Required]
        public string Altura { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Required]
        [DisplayName("Massa Corporal: ")]
        public string MassaMagra { get; set; }

        [DisplayName("Tipo de Treino: ")]
        public string TipoTreino { get; set; }

        [DisplayName("Tempo de Treino: ")]
        public string TempoTreino { get; set; }

        [DisplayName("Sugestão para aluno: ")]
        public string Sugestao { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }

        //Um aluno pode ter um professor
        public Guid PersonalId { get; set; }

    }
}
