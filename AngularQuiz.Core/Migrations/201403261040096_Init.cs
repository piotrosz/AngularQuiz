namespace AngularQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryQuestionOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryQuestionId = c.Int(nullable: false),
                        Category = c.String(nullable: false, maxLength: 1024),
                        Content = c.String(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryQuestion", t => t.CategoryQuestionId, cascadeDelete: true)
                .Index(t => t.CategoryQuestionId);
            
            CreateTable(
                "dbo.CategoryQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.OpenQuestionCorrectAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenQuestionId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OpenQuestion", t => t.OpenQuestionId, cascadeDelete: true)
                .Index(t => t.OpenQuestionId);
            
            CreateTable(
                "dbo.OpenQuestionCorrectAnswerOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenQuestionCorrectAnswerId = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OpenQuestionCorrectAnswer", t => t.OpenQuestionCorrectAnswerId, cascadeDelete: true)
                .Index(t => t.OpenQuestionCorrectAnswerId);
            
            CreateTable(
                "dbo.OpenQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.Quiz",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        View = c.String(nullable: false, maxLength: 255),
                        QuizPackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuizPackage", t => t.QuizPackageId, cascadeDelete: true)
                .Index(t => t.QuizPackageId);
            
            CreateTable(
                "dbo.QuizPackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SortQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.SortQuestionOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 1024),
                        OrderId = c.Int(nullable: false),
                        PresentedOrderId = c.Int(nullable: false),
                        SortQuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SortQuestion", t => t.SortQuestionId, cascadeDelete: true)
                .Index(t => t.SortQuestionId);
            
            CreateTable(
                "dbo.TestQuestion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quiz", t => t.QuizId, cascadeDelete: true)
                .Index(t => t.QuizId);
            
            CreateTable(
                "dbo.TestQuestionOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 1024),
                        TestQuestionId = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestQuestion", t => t.TestQuestionId, cascadeDelete: true)
                .Index(t => t.TestQuestionId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserQuizScorePackage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserQuizScore",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserQuizScorePackageId = c.Int(nullable: false),
                        QuizId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        MaxPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TestQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.TestQuestionOption", "TestQuestionId", "dbo.TestQuestion");
            DropForeignKey("dbo.SortQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.SortQuestionOption", "SortQuestionId", "dbo.SortQuestion");
            DropForeignKey("dbo.Quiz", "QuizPackageId", "dbo.QuizPackage");
            DropForeignKey("dbo.OpenQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.CategoryQuestion", "QuizId", "dbo.Quiz");
            DropForeignKey("dbo.OpenQuestionCorrectAnswer", "OpenQuestionId", "dbo.OpenQuestion");
            DropForeignKey("dbo.OpenQuestionCorrectAnswerOption", "OpenQuestionCorrectAnswerId", "dbo.OpenQuestionCorrectAnswer");
            DropForeignKey("dbo.CategoryQuestionOption", "CategoryQuestionId", "dbo.CategoryQuestion");
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "User_Id" });
            DropIndex("dbo.TestQuestion", new[] { "QuizId" });
            DropIndex("dbo.TestQuestionOption", new[] { "TestQuestionId" });
            DropIndex("dbo.SortQuestion", new[] { "QuizId" });
            DropIndex("dbo.SortQuestionOption", new[] { "SortQuestionId" });
            DropIndex("dbo.Quiz", new[] { "QuizPackageId" });
            DropIndex("dbo.OpenQuestion", new[] { "QuizId" });
            DropIndex("dbo.CategoryQuestion", new[] { "QuizId" });
            DropIndex("dbo.OpenQuestionCorrectAnswer", new[] { "OpenQuestionId" });
            DropIndex("dbo.OpenQuestionCorrectAnswerOption", new[] { "OpenQuestionCorrectAnswerId" });
            DropIndex("dbo.CategoryQuestionOption", new[] { "CategoryQuestionId" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserQuizScore");
            DropTable("dbo.UserQuizScorePackage");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TestQuestionOption");
            DropTable("dbo.TestQuestion");
            DropTable("dbo.SortQuestionOption");
            DropTable("dbo.SortQuestion");
            DropTable("dbo.QuizPackage");
            DropTable("dbo.Quiz");
            DropTable("dbo.OpenQuestion");
            DropTable("dbo.OpenQuestionCorrectAnswerOption");
            DropTable("dbo.OpenQuestionCorrectAnswer");
            DropTable("dbo.CategoryQuestion");
            DropTable("dbo.CategoryQuestionOption");
        }
    }
}
