using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Aulas")]
    public class Aula
    {
        public Aula()
        {
            AulaID = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid AulaID { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        [DisplayName("Tipo da Aula: ")]
        public string TipoAula { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(5000)]
        [DisplayName("Descrição: ")]
        public string Descricao { get; set; }
    }
}
