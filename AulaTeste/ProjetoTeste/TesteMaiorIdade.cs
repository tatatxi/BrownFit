using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AulaTeste;

namespace ProjetoTeste
{
    [TestClass]
    public class TesteMaiorIdade
    {
        Pessoa pessoa = new Pessoa();

        [TestMethod]
        public void TesteMaiorVerdadeiro()
        {
            Pessoa pessoa = new Pessoa();

            pessoa.DataNascimento = new DateTime(1994, 05, 18);

            int idade = DateTime.Today.Year - pessoa.DataNascimento.Year;

            Assert.IsTrue(idade >= 18);
        }
    }
}
