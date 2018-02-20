namespace Learning.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqKeyToUser : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "Username");
            CreateIndex("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "Username" });
        }
    }
}
