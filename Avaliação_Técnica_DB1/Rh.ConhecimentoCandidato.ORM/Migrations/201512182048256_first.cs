namespace Rh.ConhecimentoCandidato.ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidatoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCandidato = c.String(nullable: false, maxLength: 50),
                        Idade = c.Int(nullable: false),
                        Email = c.String(),
                        Telefone1 = c.Int(nullable: false),
                        Telefone2 = c.Int(nullable: false),
                        LinkedInURL = c.String(),
                        FacebookURL = c.String(),
                        VagaId = c.Int(nullable: false),
                        Detalhes = c.String(),
                        Pontuacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vagas", t => t.VagaId, cascadeDelete: true)
                .Index(t => t.VagaId);
            
            CreateTable(
                "dbo.Tecnologias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeTecnologia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeVaga = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TecnologiaCandidatoes",
                c => new
                    {
                        Tecnologia_Id = c.Int(nullable: false),
                        Candidato_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tecnologia_Id, t.Candidato_Id })
                .ForeignKey("dbo.Tecnologias", t => t.Tecnologia_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidatoes", t => t.Candidato_Id, cascadeDelete: true)
                .Index(t => t.Tecnologia_Id)
                .Index(t => t.Candidato_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidatoes", "VagaId", "dbo.Vagas");
            DropForeignKey("dbo.TecnologiaCandidatoes", "Candidato_Id", "dbo.Candidatoes");
            DropForeignKey("dbo.TecnologiaCandidatoes", "Tecnologia_Id", "dbo.Tecnologias");
            DropIndex("dbo.TecnologiaCandidatoes", new[] { "Candidato_Id" });
            DropIndex("dbo.TecnologiaCandidatoes", new[] { "Tecnologia_Id" });
            DropIndex("dbo.Candidatoes", new[] { "VagaId" });
            DropTable("dbo.TecnologiaCandidatoes");
            DropTable("dbo.Vagas");
            DropTable("dbo.Tecnologias");
            DropTable("dbo.Candidatoes");
        }
    }
}
