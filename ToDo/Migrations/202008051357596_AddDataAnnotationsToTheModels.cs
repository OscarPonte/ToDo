namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToTheModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoTasks", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ToDoSteps", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.ToDoUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoUsers", "Name", c => c.String());
            AlterColumn("dbo.ToDoSteps", "Name", c => c.String());
            AlterColumn("dbo.ToDoTasks", "Name", c => c.String());
        }
    }
}
