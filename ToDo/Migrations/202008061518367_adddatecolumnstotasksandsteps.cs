namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddatecolumnstotasksandsteps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoSteps", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.ToDoSteps", "DateEnded", c => c.DateTime());
            AddColumn("dbo.ToDoTasks", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.ToDoTasks", "DateEnded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoTasks", "DateEnded");
            DropColumn("dbo.ToDoTasks", "DateAdded");
            DropColumn("dbo.ToDoSteps", "DateEnded");
            DropColumn("dbo.ToDoSteps", "DateAdded");
        }
    }
}
