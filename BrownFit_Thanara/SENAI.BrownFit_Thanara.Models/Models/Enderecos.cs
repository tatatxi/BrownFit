﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    public class Enderecos
    {
        [Table("Enderecos")]
        public class Endereco
        {
            public Endereco()
            {
                EnderecoId = Guid.NewGuid();
            }

            public Guid EnderecoId { get; set; }
            public string Estado { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string Cep { get; set; }
            public string Complemento { get; set; }

            public Guid Aluno { get; set; }

            public Guid Personal { get; set; }

            public Guid Admin { get; set; }
        }
    }
}
