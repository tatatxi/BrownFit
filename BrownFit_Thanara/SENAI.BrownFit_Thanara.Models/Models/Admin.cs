using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Admins")]
    public class Admin
    {
        public Admin()
        {
            AdminId = Guid.NewGuid();
            Permissao = "ADMIN";
        }

        [Key]
        public Guid AdminId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Matricula { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        [Required]
        public string Senha { get; set; }

        //Adm pode cadastrar um personal
        public Guid PersonalId { get; set; }

        //Adm pode cadastrar uma recepcionista
        public Guid RecepcionistaId { get; set; }

        public string Permissao { get; set; }

    }
}
