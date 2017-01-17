namespace OnlineMark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAddFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Aim", c => c.String());
            AddColumn("dbo.Courses", "ProgramOfCourse", c => c.String());
            AddColumn("dbo.Courses", "Themes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Themes");
            DropColumn("dbo.Courses", "ProgramOfCourse");
            DropColumn("dbo.Courses", "Aim");
        }
    }
}
