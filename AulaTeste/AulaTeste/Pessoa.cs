using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTeste
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        public bool MaiorIdade()
        {
            int idade = DateTime.Today.Year - this.DataNascimento.Year;

            if (idade >= 18)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}
