namespace ToDo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUserTaskTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoUserToDoTasks",
                c => new
                {
                    ToDoUser_Id = c.Int(nullable: false),
                    ToDoTask_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ToDoUser_Id, t.ToDoTask_Id })
                .ForeignKey("dbo.ToDoUsers", t => t.ToDoUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.ToDoTasks", t => t.ToDoTask_Id, cascadeDelete: true)
                .Index(t => t.ToDoUser_Id)
                .Index(t => t.ToDoTask_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ToDoUserToDoTasks", "ToDoTask_Id", "dbo.ToDoTasks");
            DropForeignKey("dbo.ToDoUserToDoTasks", "ToDoUser_Id", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoUserToDoTasks", new[] { "ToDoTask_Id" });
            DropIndex("dbo.ToDoUserToDoTasks", new[] { "ToDoUser_Id" });
            DropTable("dbo.ToDoUserToDoTasks");
        }
    }
}
