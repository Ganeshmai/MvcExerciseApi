namespace MVC_2Excerise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropPrimaryKey("dbo.Units");
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Units", "Name", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Units", "Id");
            AddForeignKey("dbo.Products", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Units");
            DropPrimaryKey("dbo.Units");
            AlterColumn("dbo.Units", "Name", c => c.String());
            AlterColumn("dbo.Units", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AddPrimaryKey("dbo.Units", "Id");
            AddForeignKey("dbo.Products", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
    }
}
