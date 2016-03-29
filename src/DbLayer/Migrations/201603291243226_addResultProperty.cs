namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResultProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Result", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Result");
        }
    }
}
