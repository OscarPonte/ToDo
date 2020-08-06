namespace ToDo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateFluentApi1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoUserToDoTasks", "ToDoTaskId", "dbo.ToDoTasks");
            DropForeignKey("dbo.ToDoUserToDoTasks", "ToDoUserId", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoUserToDoTasks", new[] { "ToDoTaskId" });
            DropIndex("dbo.ToDoUserToDoTasks", new[] { "ToDoUserId" });
            DropTable("dbo.ToDoUserToDoTasks");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ToDoUserToDoTasks",
                c => new
                {
                    ToDoUserId = c.Int(nullable: false),
                    ToDoTaskId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ToDoUserId, t.ToDoTaskId })
                .ForeignKey("dbo.ToDoUsers", t => t.ToDoUserId, cascadeDelete: true)
                .ForeignKey("dbo.ToDoTasks", t => t.ToDoTaskId, cascadeDelete: true)
                .Index(t => t.ToDoUserId)
                .Index(t => t.ToDoTaskId);
        }
    }
}
