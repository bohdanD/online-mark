namespace OnlineMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dell_pass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Lecturers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Lecturers", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Group", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Login", c => c.String(nullable: false));
            DropColumn("dbo.Lecturers", "Password");
            DropColumn("dbo.Students", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Password", c => c.String());
            AddColumn("dbo.Lecturers", "Password", c => c.String());
            AlterColumn("dbo.Students", "Login", c => c.String());
            AlterColumn("dbo.Students", "Group", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Lecturers", "Login", c => c.String());
            AlterColumn("dbo.Lecturers", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
