using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Data.Repositorios;
using SENAI.BrownFit_Thanara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Dominio.Servicos
{
    public class PerfilServico
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();
        private PerfilRepository perfilRepository = new PerfilRepository();

        public void Create(Perfil perfil)
        {
            perfil.PerfilId = Guid.NewGuid();
            perfilRepository.Create(perfil);
        }

        public void Edit(Perfil perfil)
        {
            perfilRepository.Editar(perfil);
        }

        public 
    }
}
