namespace MVC_2Excerise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identityoff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Units");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Units", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Units");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Units", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
