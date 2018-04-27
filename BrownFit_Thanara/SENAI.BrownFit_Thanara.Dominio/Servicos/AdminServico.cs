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
    public class AdminServico
    {
        public Usr EfetuarLogin(string matricula, string senha)
        {
            AdminRepositorio adminRepositorio = new AdminRepositorio();
            Admin admin = adminRepositorio.EfetuarLogin(matricula, Criptografia.GetMD5Hash(senha));

            return admin;
        }
    }
}
