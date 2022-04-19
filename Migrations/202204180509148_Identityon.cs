namespace MVC_2Excerise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identityon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Categories");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Categories");
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Categories", "Id");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
