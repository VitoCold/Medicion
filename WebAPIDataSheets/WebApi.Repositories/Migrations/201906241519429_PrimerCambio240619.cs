namespace WebApi.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimerCambio240619 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tuberia", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tuberia", "Nombre", c => c.Int(nullable: false));
        }
    }
}
