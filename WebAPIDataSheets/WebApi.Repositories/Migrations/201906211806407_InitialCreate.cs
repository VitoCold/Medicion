namespace WebApi.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Industria",
                c => new
                    {
                        IndustriaId = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                        Nombre = c.String(),
                        CategoriaId = c.Int(nullable: false),
                        SedeId = c.Int(nullable: false),
                        TuberiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndustriaId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Sede", t => t.SedeId, cascadeDelete: true)
                .ForeignKey("dbo.Tuberia", t => t.TuberiaId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.SedeId)
                .Index(t => t.TuberiaId);
            
            CreateTable(
                "dbo.Elemento",
                c => new
                    {
                        ElementoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IndustriaId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        TipoElementoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ElementoId)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Industria", t => t.IndustriaId, cascadeDelete: true)
                .ForeignKey("dbo.TipoElemento", t => t.TipoElementoId, cascadeDelete: true)
                .Index(t => t.IndustriaId)
                .Index(t => t.EstadoId)
                .Index(t => t.TipoElementoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.TipoElemento",
                c => new
                    {
                        TipoElementoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ClaseElementoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TipoElementoId)
                .ForeignKey("dbo.ClaseElemento", t => t.ClaseElementoId, cascadeDelete: true)
                .Index(t => t.ClaseElementoId);
            
            CreateTable(
                "dbo.ClaseElemento",
                c => new
                    {
                        ClaseElementoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ClaseElementoId);
            
            CreateTable(
                "dbo.Sede",
                c => new
                    {
                        SedeId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.SedeId);
            
            CreateTable(
                "dbo.Tuberia",
                c => new
                    {
                        TuberiaId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TuberiaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Industria", "TuberiaId", "dbo.Tuberia");
            DropForeignKey("dbo.Industria", "SedeId", "dbo.Sede");
            DropForeignKey("dbo.Elemento", "TipoElementoId", "dbo.TipoElemento");
            DropForeignKey("dbo.TipoElemento", "ClaseElementoId", "dbo.ClaseElemento");
            DropForeignKey("dbo.Elemento", "IndustriaId", "dbo.Industria");
            DropForeignKey("dbo.Elemento", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Industria", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.TipoElemento", new[] { "ClaseElementoId" });
            DropIndex("dbo.Elemento", new[] { "TipoElementoId" });
            DropIndex("dbo.Elemento", new[] { "EstadoId" });
            DropIndex("dbo.Elemento", new[] { "IndustriaId" });
            DropIndex("dbo.Industria", new[] { "TuberiaId" });
            DropIndex("dbo.Industria", new[] { "SedeId" });
            DropIndex("dbo.Industria", new[] { "CategoriaId" });
            DropTable("dbo.Tuberia");
            DropTable("dbo.Sede");
            DropTable("dbo.ClaseElemento");
            DropTable("dbo.TipoElemento");
            DropTable("dbo.Estado");
            DropTable("dbo.Elemento");
            DropTable("dbo.Industria");
            DropTable("dbo.Categoria");
        }
    }
}
