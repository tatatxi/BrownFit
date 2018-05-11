using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Relatorios")]
    public class Relatorio
    {
        public Relatorio()
        {
            RelatorioId = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid RelatorioId { get; set; }

        public int ResultadoIMC { get; set; }

        public string ResultadoMassaMagra { get; set; }

        public Guid UsuarioId { get; set; }

        public Guid PerfilId { get; set; }

        public Guid AlunoId { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Perfil Perfil { get; set; }

        //tentar definir propriedade que todos podem gerar relatorio do aluno
    }
}
