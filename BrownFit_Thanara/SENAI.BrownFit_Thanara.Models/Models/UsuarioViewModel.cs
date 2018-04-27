using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Algo de errado não esta certo :s")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Algo de errado não esta certo :s")]
        public string Senha { get; set; }
    }
}
