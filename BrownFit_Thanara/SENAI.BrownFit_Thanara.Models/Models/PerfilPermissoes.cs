using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    public class PerfilPermissoes
    {
        public PerfilPermissoes()
        {
            PerfilPermissoesId = Guid.NewGuid();
        }

        [Key]
        public Guid PerfilPermissoesId { get; set; }
    }
}
