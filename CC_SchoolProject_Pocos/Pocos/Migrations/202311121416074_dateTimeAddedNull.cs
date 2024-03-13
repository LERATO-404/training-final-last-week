namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimeAddedNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Date_Of_Birth", c => c.DateTime());
            AlterColumn("dbo.Teachers", "Start_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Start_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Teachers", "Date_Of_Birth", c => c.DateTime(nullable: false));
        }
    }
}
