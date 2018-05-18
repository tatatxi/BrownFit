using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Agenda")]
    public class Agenda
    {
        public Agenda()
        {
            AgendaID = Guid.NewGuid();
        }

        [Key]
        public Guid AgendaID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAula { get; set; }

        public virtual Usuario Professor { get; set; }

        public string Descricao { get; set; }

        public virtual List<Usuario> Alunos { get; set; }

        //propriedade que apenas o perfil de personal poderá agendar aulas
        //e quais campos estão na aula

    }
}
