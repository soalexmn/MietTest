namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEntities1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionResults", "QuestionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionResults", "QuestionId");
        }
    }
}
