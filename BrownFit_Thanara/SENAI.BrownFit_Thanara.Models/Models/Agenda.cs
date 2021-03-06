﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SENAI.BrownFit_Thanara.Models
{
    [Table("Agenda")]
    public class Agenda
    {
        public Agenda()
        {
            AgendaID = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid AgendaID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Data da Aula: ")]
        [Column(TypeName = "DateTime")]
        public DateTime DataAula { get; set; }

        public Guid AulaID { get; set; }
        public Guid UsuarioId { get; set; }

        public virtual Aula Aula { get; set; }
        public virtual Usuario Professor { get; set; }

        [DisplayName("Descrição da Aula: ")]
        [Column(TypeName = "varchar")]
        [MaxLength(5000)]
        public string Descricao { get; set; }

        public virtual List<AgendaAluno> Alunos { get; set; }
    }
}
