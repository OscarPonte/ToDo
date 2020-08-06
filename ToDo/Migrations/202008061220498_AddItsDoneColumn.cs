namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItsDoneColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoSteps", "TheStepItsDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.ToDoTasks", "TheTaskItsDone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDoTasks", "TheTaskItsDone");
            DropColumn("dbo.ToDoSteps", "TheStepItsDone");
        }
    }
}
