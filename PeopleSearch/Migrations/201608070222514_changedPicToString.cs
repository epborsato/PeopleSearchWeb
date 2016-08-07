namespace PeopleSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPicToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Picture", c => c.Binary());
        }
    }
}
