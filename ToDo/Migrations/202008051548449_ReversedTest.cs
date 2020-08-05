namespace ToDo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ReversedTest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoSteps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.ToDoSteps", "ToDoTaskId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoSteps", "ToDoTaskId");
            AddForeignKey("dbo.ToDoSteps", "ToDoTaskId", "dbo.ToDoTasks", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.ToDoSteps", "ToDoTaskId", "dbo.ToDoTasks");
            DropIndex("dbo.ToDoSteps", new[] { "ToDoTaskId" });
            DropColumn("dbo.ToDoSteps", "ToDoTaskId");
            DropTable("dbo.ToDoSteps");
        }
    }
}
