using SENAI.BrownFit_Thanara.Data.Context;
using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Data.Repositorios
{
    public class AdminRepositorio
    {
        private Brown_ThanaraContext db = new Brown_ThanaraContext();

        public Admin EfetuarLogin(string matricula, string senha)
        {
            return db.Admins.Where(c => c.Matricula.Equals(matricula) && c.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}
