namespace Gastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                {
                    IdCategory = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.IdCategory);

            AddColumn("dbo.Gasto", "CategoriaId", c => c.Int(nullable: false));
            AddColumn("dbo.Gasto", "Categoria_IdCategory", c => c.Int());
            CreateIndex("dbo.Gasto", "Categoria_IdCategory");
            AddForeignKey("dbo.Gasto", "Categoria_IdCategory", "dbo.Categoria", "IdCategory");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Gasto", "Categoria_IdCategory", "dbo.Categoria");
            DropIndex("dbo.Gasto", new[] { "Categoria_IdCategory" });
            DropColumn("dbo.Gasto", "Categoria_IdCategory");
            DropColumn("dbo.Gasto", "CategoriaId");
            DropTable("dbo.Categoria");
        }
    }
}
