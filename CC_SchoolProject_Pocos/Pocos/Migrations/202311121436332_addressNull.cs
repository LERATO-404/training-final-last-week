namespace Pocos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Teachers", new[] { "Address_Id" });
            AlterColumn("dbo.Teachers", "Address_Id", c => c.Int());
            CreateIndex("dbo.Teachers", "Address_Id");
            AddForeignKey("dbo.Teachers", "Address_Id", "dbo.Addresses", "Address_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Teachers", new[] { "Address_Id" });
            AlterColumn("dbo.Teachers", "Address_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "Address_Id");
            AddForeignKey("dbo.Teachers", "Address_Id", "dbo.Addresses", "Address_Id", cascadeDelete: true);
        }
    }
}
