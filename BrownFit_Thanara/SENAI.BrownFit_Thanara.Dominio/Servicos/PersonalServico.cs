using SENAI.BrownFit_Thanara.Data.Repositorios;
using SENAI.BrownFit_Thanara.Models.Models;
using SENAI.BrownFit_Thanara.Util.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Dominio.Servicos
{
    public class PersonalServico
    {
        public Personal EfetuarLogin(string matricula, string senha)
        {
            PersonalRepositorio personalRepositorio = new PersonalRepositorio();
            Personal personal = personalRepositorio.EfetuarLogin(matricula, Criptografia.GetMD5Hash(senha));

            return personal;
        }
    }
}
