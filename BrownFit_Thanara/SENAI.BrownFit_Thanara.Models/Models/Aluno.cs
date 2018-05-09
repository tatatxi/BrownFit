﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public Aluno()
        {
            AlunoID = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid AlunoID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "O Nome do Aluno é obrigatório.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome: ")]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "O Sobrenome do Aluno é obrigatório.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Sobrenome: ")]
        public string Sobrenome { get; set; }

        [StringLength(11, MinimumLength = 11)]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Column(TypeName = "varchar")]
        public string CPF { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [DisplayName("E-mail do Aluno: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data de nascimento é obrigatório.")]
        [DisplayName("Data de Nascimento: ")]
        public DateTime DataNascimento { get; set; }


        [DataType(DataType.Date)]
        [DisplayName("Data de Cadastro: ")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [DisplayName("Situação: ")]
        public bool Ativo { get; set; }

        [Required]
        public bool Excluido { get; set; }

        [StringLength(15, MinimumLength = 2)]
        public string Permissao { get; set; }

        [Required(ErrorMessage = "Peso é obrigatório.")]
        [DisplayName("Peso: ")]
        [Column(TypeName = "varchar")]
        public string Peso { get; set; }

        [Required(ErrorMessage = "Altura é obrigatório.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Altura: ")]
        public string Altura { get; set; }

        [Required(ErrorMessage = "Massa corporal é obrigatório.")]
        [DisplayName("Massa Corporal: ")]
        [Column(TypeName = "varchar")]
        public string MassaMagra { get; set; }

        [DisplayName("Tipo de Treino: ")]
        [Column(TypeName = "varchar")]
        public string TipoTreino { get; set; }

        [DisplayName("Tempo de Treino: ")]
        [Column(TypeName = "varchar")]
        public string TempoTreino { get; set; }

        [DisplayName("Sugestão para aluno: ")]
        [Column(TypeName = "varchar")]
        public string Sugestao { get; set; }

    }
}
