using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    public class PerfilPermissoes
    {
        public PerfilPermissoes()
        {
            PerfilPermissoesID = Guid.NewGuid();
        }

        [Key]
        public Guid PerfilPermissoesID { get; set; }

        public Guid RecepcionistaID { get; set; }

        public Guid PersonalID { get; set; }

        public Guid AdminID { get; set; }

        [ForeignKey("RecepcionistaID")]
        public virtual Recepcionista Recepcionista { get; set; }

        [ForeignKey("PersonalID")]
        public virtual Personal Personal { get; set; }

        [ForeignKey("AdminID")]
        public virtual Admin Admin { get; set; }

    }
}
