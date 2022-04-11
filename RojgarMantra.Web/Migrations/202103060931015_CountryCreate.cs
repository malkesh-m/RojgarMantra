namespace RojgarMantra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SmtpDetails", "Smtpid", c => c.String());
            AddColumn("dbo.SmtpDetails", "Emailid", c => c.String());
            DropColumn("dbo.SmtpDetails", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SmtpDetails", "Email", c => c.String());
            DropColumn("dbo.SmtpDetails", "Emailid");
            DropColumn("dbo.SmtpDetails", "Smtpid");
        }
    }
}
