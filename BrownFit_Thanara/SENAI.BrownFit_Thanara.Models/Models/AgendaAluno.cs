using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("AgendaAluno")]
    public class AgendaAluno
    {
        public AgendaAluno()
        {
            AgendaAlunoId = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid AgendaAlunoId { get; set; }

        public Guid AlunoID { get; set; }
        public Guid AgendaID { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual Agenda Agenda { get; set; }

    }
}
