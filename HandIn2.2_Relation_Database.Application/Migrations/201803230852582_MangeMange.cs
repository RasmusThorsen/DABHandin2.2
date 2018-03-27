namespace HandIn2._2_Relation_Database.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MangeMange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "Person_PersonID", "dbo.People");
            DropIndex("dbo.Adresses", new[] { "Person_PersonID" });
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Adresse_AdresseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Adresse_AdresseID })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Adresses", t => t.Adresse_AdresseID, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Adresse_AdresseID);
            
            DropColumn("dbo.Adresses", "Person_PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresses", "Person_PersonID", c => c.Int());
            DropForeignKey("dbo.PersonAdresses", "Adresse_AdresseID", "dbo.Adresses");
            DropForeignKey("dbo.PersonAdresses", "Person_PersonID", "dbo.People");
            DropIndex("dbo.PersonAdresses", new[] { "Adresse_AdresseID" });
            DropIndex("dbo.PersonAdresses", new[] { "Person_PersonID" });
            DropTable("dbo.PersonAdresses");
            CreateIndex("dbo.Adresses", "Person_PersonID");
            AddForeignKey("dbo.Adresses", "Person_PersonID", "dbo.People", "PersonID");
        }
    }
}
