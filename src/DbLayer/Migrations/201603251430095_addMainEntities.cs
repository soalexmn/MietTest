namespace DbLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMainEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tests", new[] { "User_Id" });
            CreateTable(
                "dbo.AnswerVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.QuestionResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCorrect = c.Boolean(nullable: false),
                        Result = c.String(),
                        TestResult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestResults", t => t.TestResult_Id, cascadeDelete: true)
                .Index(t => t.TestResult_Id);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.String(maxLength: 128),
                        TestId = c.Int(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Test_Id = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.TestId)
                .Index(t => t.Test_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Questions", "Body", c => c.String());
            AddColumn("dbo.Questions", "Test_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tests", "Title", c => c.String());
            AddColumn("dbo.Tests", "Description", c => c.String());
            AlterColumn("dbo.Tests", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Questions", "Test_Id");
            CreateIndex("dbo.Tests", "User_Id");
            AddForeignKey("dbo.Questions", "Test_Id", "dbo.Tests", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tests", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestResults", "userId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestResults", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestResults", "TestId", "dbo.Tests");
            DropForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.QuestionResults", "TestResult_Id", "dbo.TestResults");
            DropForeignKey("dbo.AnswerVariants", "Question_Id", "dbo.Questions");
            DropIndex("dbo.Tests", new[] { "User_Id" });
            DropIndex("dbo.TestResults", new[] { "User_Id" });
            DropIndex("dbo.TestResults", new[] { "Test_Id" });
            DropIndex("dbo.TestResults", new[] { "TestId" });
            DropIndex("dbo.TestResults", new[] { "userId" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.QuestionResults", new[] { "TestResult_Id" });
            DropIndex("dbo.AnswerVariants", new[] { "Question_Id" });
            AlterColumn("dbo.Tests", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Tests", "Description");
            DropColumn("dbo.Tests", "Title");
            DropColumn("dbo.Questions", "Test_Id");
            DropColumn("dbo.Questions", "Body");
            DropTable("dbo.TestResults");
            DropTable("dbo.QuestionResults");
            DropTable("dbo.AnswerVariants");
            CreateIndex("dbo.Tests", "User_Id");
            AddForeignKey("dbo.Tests", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
