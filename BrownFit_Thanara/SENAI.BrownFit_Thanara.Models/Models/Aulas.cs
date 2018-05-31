using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENAI.BrownFit_Thanara.Models.Models
{
    [Table("Aulas")]
    public class Aula
    {
        public Aula()
        {
            AulaID = Guid.NewGuid();
        }

        [Key]
        [Column("Id")]
        public Guid AulaID { get; set; }

        public string TipoAulas { get; set; }

        public string Descricao { get; set; }

        public Usuario Professor { get; set; }

        public List<Aula> ListaAulas()
        {
            return new List<Aula>
            {
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Aerobico", Descricao = "tipo de atividade física que através de movimentos rápidos e ritmados provoca a oxigenação das células musculares e elevado gasto calórico" },
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Abdominal", Descricao = "para desenvolvimento e fortalecimento da musculatura abdominal, principalmente do músculo reto abdominal. É também um modelo pertencente ao método Hiit" },
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Musculação", Descricao = "definição é possível utilizarmos algumas metodologias diferentes, como treinamento em circuito (fazendo vários exercícios em sequência e sem descanso) ou descanso ativo (no intervalo de um exercício e outro você corre, faz abdominais ou outra atividade)" },
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Flexibilidade", Descricao = "flexibilidade muscular é a capacidade de um músculo se esticar sem sofrer danos. Esta magnitude está determinada pelo intervalo de movimento dos músculos que formam uma articulação" },
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Danças", Descricao = "Zumba, Ballet, Sh´Bam, Street Dance, Body Jam, Dança de Salão, Sapateado, fast Dance, Jazz, Dança do Ventre" },
                new Aula { AulaID = Guid.NewGuid(), TipoAulas = "Lutas", Descricao = "As lutas e as artes marciais apresentam, em suas origens, características atribuídas à sobrevivência, ao exercício físico, ao treinamento militar, à defesa e ao ataque pessoal, além das implicações das tradições culturais, religiosas e filosóficas" }
            };
            
        }

    }
}
