namespace HandIn2._2_Relation_Database.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdressType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PersonAdresses", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "Adresse_AdresseID", "dbo.Adresses");
            DropIndex("dbo.PersonAdresses", new[] { "Person_PersonID" });
            DropIndex("dbo.PersonAdresses", new[] { "Adresse_AdresseID" });
            AddColumn("dbo.Adresses", "Type", c => c.String());
            AddColumn("dbo.Adresses", "Person_PersonID", c => c.Int());
            CreateIndex("dbo.Adresses", "Person_PersonID");
            AddForeignKey("dbo.Adresses", "Person_PersonID", "dbo.People", "PersonID");
            DropTable("dbo.PersonAdresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Adresse_AdresseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Adresse_AdresseID });
            
            DropForeignKey("dbo.Adresses", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Adresses", new[] { "Person_PersonID" });
            DropColumn("dbo.Adresses", "Person_PersonID");
            DropColumn("dbo.Adresses", "Type");
            CreateIndex("dbo.PersonAdresses", "Adresse_AdresseID");
            CreateIndex("dbo.PersonAdresses", "Person_PersonID");
            AddForeignKey("dbo.PersonAdresses", "Adresse_AdresseID", "dbo.Adresses", "AdresseID", cascadeDelete: true);
            AddForeignKey("dbo.PersonAdresses", "Person_PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
    }
}
