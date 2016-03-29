namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tests", "UserId");
            AddForeignKey("dbo.Tests", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tests", new[] { "UserId" });
            DropColumn("dbo.Tests", "UserId");
        }
    }
}
