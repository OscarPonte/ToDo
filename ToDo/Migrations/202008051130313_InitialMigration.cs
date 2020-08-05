namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "ToDoTasks");
            CreateTable(
                "dbo.ToDoUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToDoUsers");
            RenameTable(name: "dbo.ToDoTasks", newName: "Users");
        }
    }
}
