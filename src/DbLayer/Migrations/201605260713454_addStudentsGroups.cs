namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addStudentsGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NeedTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desciption = c.String(),
                        GroupId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Group_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NeedTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.NeedTests", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserGroups", new[] { "Group_Id" });
            DropIndex("dbo.UserGroups", new[] { "User_Id" });
            DropIndex("dbo.NeedTests", new[] { "TestId" });
            DropIndex("dbo.NeedTests", new[] { "GroupId" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.NeedTests");
            DropTable("dbo.Groups");
        }
    }
}
