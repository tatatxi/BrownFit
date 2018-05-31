using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("Relatorio")]
    public class Relatorio
    {
        public Relatorio()
        {
            RelatorioID = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid RelatorioID { get; set; }

        public virtual List<Aluno> Alunos { get; set; }

        public virtual List<Usuario> Professor { get; set; }

    }
}
