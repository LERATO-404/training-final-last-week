namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Address_Id = c.Int(nullable: false, identity: true),
                        Address_Line = c.String(),
                        Suburb = c.String(),
                        Postal_Code = c.String(),
                    })
                .PrimaryKey(t => t.Address_Id);
            
            CreateTable(
                "dbo.Guardians",
                c => new
                    {
                        Guardian_Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Relationship = c.String(),
                        Contact = c.String(),
                        Address_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Guardian_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        Learner_Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Guardian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Learner_Id)
                .ForeignKey("dbo.Guardians", t => t.Guardian_Id, cascadeDelete: true)
                .Index(t => t.Guardian_Id);
            
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        Assessment_Id = c.Int(nullable: false, identity: true),
                        Assessment_Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                        Due_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Assessment_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false, identity: true),
                        Subject_Name = c.String(),
                        Subject_Code = c.String(),
                        Subject_Description = c.String(),
                    })
                .PrimaryKey(t => t.Subject_Id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        TeacherSubject_Id = c.Int(nullable: false, identity: true),
                        Subject_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherSubject_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Teacher_Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Contact_Number = c.String(),
                        Email_Address = c.String(),
                        Address_Id = c.Int(nullable: false),
                        Username = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Teacher_Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Mark_Id = c.Int(nullable: false, identity: true),
                        Mark_Obtained = c.Int(nullable: false),
                        Comment = c.String(),
                        Learner_Id = c.Int(nullable: false),
                        Assessment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Mark_Id)
                .ForeignKey("dbo.Assessments", t => t.Assessment_Id, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.Learner_Id, cascadeDelete: true)
                .Index(t => t.Learner_Id)
                .Index(t => t.Assessment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Marks", "Learner_Id", "dbo.Learners");
            DropForeignKey("dbo.Marks", "Assessment_Id", "dbo.Assessments");
            DropForeignKey("dbo.Assessments", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.TeacherSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Learners", "Guardian_Id", "dbo.Guardians");
            DropForeignKey("dbo.Guardians", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Marks", new[] { "Assessment_Id" });
            DropIndex("dbo.Marks", new[] { "Learner_Id" });
            DropIndex("dbo.Teachers", new[] { "Address_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.Assessments", new[] { "SubjectId" });
            DropIndex("dbo.Learners", new[] { "Guardian_Id" });
            DropIndex("dbo.Guardians", new[] { "Address_Id" });
            DropTable("dbo.Marks");
            DropTable("dbo.Teachers");
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.Subjects");
            DropTable("dbo.Assessments");
            DropTable("dbo.Learners");
            DropTable("dbo.Guardians");
            DropTable("dbo.Addresses");
        }
    }
}
