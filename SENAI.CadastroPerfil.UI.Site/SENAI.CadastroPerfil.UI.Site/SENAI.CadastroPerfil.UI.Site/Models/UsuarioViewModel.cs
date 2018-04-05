using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SENAI.CadastroPerfil.UI.Site.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage ="Algo de errado não esta certo :s")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Algo de errado não esta certo :s")]
        public string Senha { get; set; }
    }
}