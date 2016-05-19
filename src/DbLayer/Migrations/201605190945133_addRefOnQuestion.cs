namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRefOnQuestion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuestionResults", "QuestionId", c => c.Int());
            CreateIndex("dbo.QuestionResults", "QuestionId");
            AddForeignKey("dbo.QuestionResults", "QuestionId", "dbo.Questions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionResults", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionResults", new[] { "QuestionId" });
            AlterColumn("dbo.QuestionResults", "QuestionId", c => c.Int(nullable: false));
        }
    }
}
