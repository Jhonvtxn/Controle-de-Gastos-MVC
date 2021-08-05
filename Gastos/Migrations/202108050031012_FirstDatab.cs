namespace Gastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDatab : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gasto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Valor = c.Double(nullable: false),
                        DateAdd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gasto");
        }
    }
}
