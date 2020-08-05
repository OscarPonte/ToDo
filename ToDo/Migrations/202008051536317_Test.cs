namespace ToDo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoTasks", "ToDoStepId", "dbo.ToDoSteps");
            DropIndex("dbo.ToDoTasks", new[] { "ToDoStepId" });
            DropColumn("dbo.ToDoTasks", "ToDoStepId");
            DropTable("dbo.ToDoSteps");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ToDoSteps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.ToDoTasks", "ToDoStepId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoTasks", "ToDoStepId");
            AddForeignKey("dbo.ToDoTasks", "ToDoStepId", "dbo.ToDoSteps", "Id", cascadeDelete: true);
        }
    }
}
