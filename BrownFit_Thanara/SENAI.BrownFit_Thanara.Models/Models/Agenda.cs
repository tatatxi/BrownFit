using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
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

        public string Professor { get; set; }

        public string Descricao { get; set; }

        public List<Usuario> Usuarios { get; set; }

        //propriedade que apenas o perfil de personal poderá agendar aulas
        //e quais campos estão na aula

    }
}
