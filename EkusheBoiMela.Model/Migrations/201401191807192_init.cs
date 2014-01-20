namespace EkusheBoiMela.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        NameInEnglish = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        NameInEnglish = c.String(),
                        StallNo = c.String(),
                        StallLat = c.Single(nullable: false),
                        StallLong = c.Single(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Isbn = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        TitleInEnglish = c.String(),
                        AuthorId = c.Long(nullable: false),
                        CatagoryId = c.Long(nullable: false),
                        PublisherId = c.Long(nullable: false),
                        Price = c.Single(nullable: false),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CoverPhoto = c.Binary(),
                    })
                .PrimaryKey(t => t.Isbn)
                .ForeignKey("dbo.Authors", t => t.AuthorId)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.AuthorId)
                .Index(t => t.CatagoryId)
                .Index(t => t.PublisherId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "CatagoryId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "CatagoryId", "dbo.Catagories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropTable("dbo.Books");
            DropTable("dbo.Publishers");
            DropTable("dbo.Authors");
            DropTable("dbo.Catagories");
        }
    }
}
