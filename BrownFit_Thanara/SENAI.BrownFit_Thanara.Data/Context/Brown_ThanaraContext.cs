using SENAI.BrownFit_Thanara.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace SENAI.BrownFit_Thanara.Data.Context
{
    public class Brown_ThanaraContext : DbContext
    {
        public Brown_ThanaraContext()
            : base("BFConnectionStrings")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfis { get; set; }

        public DbSet<UsuarioPerfil> UsuariosPerfis { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<Aula> Aulas { get; set; }

        public DbSet<AgendaAluno> AgendaAlunos { get; set; }

        public override int SaveChanges()
        {
            try
            {
                //Faz um foreach na classes e verifica qual classe possui uma propriedade chamada DataCadastro.
                foreach (var entry in ChangeTracker.Entries().Where(entry =>
                entry.Entity.GetType().GetProperty("DataCadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {  //Se estou adicionando no banco, a DataCadastro recebe DateTime.Now
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {   //Se estou efetuando um Update eu não altero a DataCadastro.
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remover a convenção do plural
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Toda string no meu sistema vai ser varchar no banco de dados.
            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar"));

            //quando uma string não tiver maxlength, ela terá um maxlength no banco de 100.
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //inicializar sem o banco
            Database.SetInitializer<Brown_ThanaraContext>(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
