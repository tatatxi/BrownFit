using System;
using System.Data.Entity.Migrations;

public partial class InitialCreate : DbMigration
{
    public override void Up()
    {
        CreateTable(
            "dbo.Alunos",
            c => new
            {
                Id = c.Guid(nullable: false),
                Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                Email = c.String(nullable: false, maxLength: 100, unicode: false),
                DataNascimento = c.DateTime(nullable: false),
                DataCadastro = c.DateTime(nullable: false),
                Ativo = c.Boolean(nullable: false),
                Excluido = c.Boolean(nullable: false),
                Permissao = c.String(maxLength: 15, unicode: false),
                Peso = c.String(nullable: false, maxLength: 100, unicode: false),
                Altura = c.String(nullable: false, maxLength: 100, unicode: false),
                MassaMagra = c.String(nullable: false, maxLength: 100, unicode: false),
                TipoTreino = c.String(maxLength: 100, unicode: false),
                TempoTreino = c.String(maxLength: 100, unicode: false),
                Sugestao = c.String(maxLength: 100, unicode: false),
            })
            .PrimaryKey(t => t.Id);

        CreateTable(
            "dbo.Perfis",
            c => new
            {
                PerfilId = c.Guid(nullable: false),
                Nome = c.String(nullable: false, maxLength: 50, unicode: false),
            })
            .PrimaryKey(t => t.PerfilId);

        CreateTable(
            "dbo.UsuariosPerfis",
            c => new
            {
                UsuarioPerfilId = c.Guid(nullable: false),
                UsuarioId = c.Guid(nullable: false),
                PerfilId = c.Guid(nullable: false),
            })
            .PrimaryKey(t => t.UsuarioPerfilId)
            .ForeignKey("dbo.Perfis", t => t.PerfilId, cascadeDelete: true)
            .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
            .Index(t => t.UsuarioId)
            .Index(t => t.PerfilId);

        CreateTable(
            "dbo.Usuarios",
            c => new
            {
                UsuarioId = c.Guid(nullable: false),
                Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                Email = c.String(nullable: false, maxLength: 50, unicode: false),
                Senha = c.String(nullable: false, maxLength: 12, unicode: false),
                DataNascimento = c.DateTime(nullable: false),
            })
            .PrimaryKey(t => t.UsuarioId);

    }

    public override void Down()
    {
        DropForeignKey("dbo.UsuariosPerfis", "UsuarioId", "dbo.Usuarios");
        DropForeignKey("dbo.UsuariosPerfis", "PerfilId", "dbo.Perfis");
        DropIndex("dbo.UsuariosPerfis", new[] { "PerfilId" });
        DropIndex("dbo.UsuariosPerfis", new[] { "UsuarioId" });
        DropTable("dbo.Usuarios");
        DropTable("dbo.UsuariosPerfis");
        DropTable("dbo.Perfis");
        DropTable("dbo.Alunos");
    }
}
