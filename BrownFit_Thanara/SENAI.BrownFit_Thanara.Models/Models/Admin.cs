using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Admins")]
    public class Admin
    {
        public Admin()
        {
            AdminID = Guid.NewGuid();
            Permissao = "ADMIN";
        }

        [Key]
        public Guid AdminID { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Matricula { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [Column(TypeName = "varchar")]
        [DisplayName("Nome: ")]
        public string Nome { get; set; }

        //Adm pode cadastrar um personal
        public Guid PersonalID { get; set; }

        //Adm pode cadastrar uma recepcionista
        public Guid RecepcionistaID { get; set; }

        //Adicionando FK do que vai estar na tabela
        [ForeignKey("RecepcionistaID")]
        public virtual Recepcionista recepcionista { get; set; }

        //Adicionando FK do que vai estar na tabela
        [ForeignKey("PersonalID")]
        public virtual Personal personal { get; set; }

        //Setando permissões
        public string Permissao { get; set; }

    }
}
