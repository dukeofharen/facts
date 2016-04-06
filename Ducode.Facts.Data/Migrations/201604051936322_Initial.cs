namespace Ducode.Facts.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Contents = c.String(unicode: false),
                        Source = c.String(unicode: false),
                        CategoryId = c.Long(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 0),
                        Updated = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Facts", new[] { "CategoryId" });
            DropTable("dbo.Facts");
            DropTable("dbo.Categories");
        }
    }
}
