namespace WcfChatDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSenderUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SenderUserName");
        }
    }
}
