using SENAI.BrownFit_Thanara.Models.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

internal sealed class Configuration : DbMigrationsConfiguration<SENAI.BrownFit_Thanara.Data.Context.Brown_ThanaraContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(SENAI.BrownFit_Thanara.Data.Context.Brown_ThanaraContext context)
    {
        context.Aulas.AddOrUpdate(
            p => p.TipoAula,
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Aeróbico", Descricao = "tipo de atividade física que através de movimentos rápidos e ritmados provoca a oxigenação das células musculares e elevado gasto calórico" },
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Abdominal", Descricao = "para desenvolvimento e fortalecimento da musculatura abdominal, principalmente do músculo reto abdominal. É também um modelo pertencente ao método Hiit" },
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Musculação", Descricao = "definição é possível utilizarmos algumas metodologias diferentes, como treinamento em circuito (fazendo vários exercícios em sequência e sem descanso) ou descanso ativo (no intervalo de um exercício e outro você corre, faz abdominais ou outra atividade)" },
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Flexibilidade", Descricao = "flexibilidade muscular é a capacidade de um músculo se esticar sem sofrer danos. Esta magnitude está determinada pelo intervalo de movimento dos músculos que formam uma articulação" },
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Danças", Descricao = "Zumba, Ballet, Sh´Bam, Street Dance, Body Jam, Dança de Salão, Sapateado, fast Dance, Jazz, Dança do Ventre" },
            new Aula { AulaID = Guid.NewGuid(), TipoAula = "Lutas", Descricao = "As lutas e as artes marciais apresentam, em suas origens, características atribuídas à sobrevivência, ao exercício físico, ao treinamento militar, à defesa e ao ataque pessoal, além das implicações das tradições culturais, religiosas e filosóficas" }
        );
    }
}
