namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        Percentage = c.Double(nullable: false),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.CampaignId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Title = c.String(maxLength: 128),
                        Campaign_CampaignId = c.Int(),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId)
                .Index(t => t.Campaign_CampaignId);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealId = c.Int(nullable: false, identity: true),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                        DealDone = c.Boolean(nullable: false),
                        Campaign_CampaignId = c.Int(),
                        Contract_ContractId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.DealId)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignId)
                .ForeignKey("dbo.Contracts", t => t.Contract_ContractId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Campaign_CampaignId)
                .Index(t => t.Contract_ContractId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.PersonInDeals",
                c => new
                    {
                        PersonInDealId = c.Int(nullable: false, identity: true),
                        Date = c.String(maxLength: 64),
                        Deal_DealId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonInDealId)
                .ForeignKey("dbo.Deals", t => t.Deal_DealId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Deal_DealId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 32),
                        SecondName = c.String(maxLength: 32),
                        Sex = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 32),
                        TelNr = c.String(maxLength: 20),
                        BankNr = c.String(maxLength: 64),
                        Locked = c.Boolean(nullable: false),
                        Money = c.Double(nullable: false),
                        Invited = c.Int(nullable: false),
                        Rating = c.Double(nullable: false),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 255),
                        DateTime = c.String(maxLength: 32),
                        Person_PersonId = c.Int(),
                        Pretension_PretensionId = c.Int(),
                        Role_RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.Pretensions", t => t.Pretension_PretensionId)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Pretension_PretensionId)
                .Index(t => t.Role_RoleId);
            
            CreateTable(
                "dbo.PersonInChats",
                c => new
                    {
                        PersonInChatId = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        Chat_ChatId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonInChatId)
                .ForeignKey("dbo.Chats", t => t.Chat_ChatId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Chat_ChatId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Pretensions",
                c => new
                    {
                        PretensionId = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                        Person_PersonId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PretensionId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.PersonInPretensions",
                c => new
                    {
                        PersonInPretensionId = c.Int(nullable: false, identity: true),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                        Person_PersonId = c.Int(),
                        Pretension_PretensionId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonInPretensionId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.Pretensions", t => t.Pretension_PretensionId)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Pretension_PretensionId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 128),
                        Content = c.String(maxLength: 1024),
                        Price = c.Double(nullable: false),
                        TrackingCode = c.String(maxLength: 128),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 255),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.DescriptionId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        Location = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                        Person_PersonId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Person_PersonId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.PersonInContracts",
                c => new
                    {
                        PersonInContractId = c.Int(nullable: false, identity: true),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                        Contract_ContractId = c.Int(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.PersonInContractId)
                .ForeignKey("dbo.Contracts", t => t.Contract_ContractId)
                .ForeignKey("dbo.People", t => t.Person_PersonId)
                .Index(t => t.Contract_ContractId)
                .Index(t => t.Person_PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInDeals", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInContracts", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInContracts", "Contract_ContractId", "dbo.Contracts");
            DropForeignKey("dbo.People", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Chats", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Pretensions", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Products", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Descriptions", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Deals", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.PersonInPretensions", "Pretension_PretensionId", "dbo.Pretensions");
            DropForeignKey("dbo.PersonInPretensions", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Pretensions", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.Chats", "Pretension_PretensionId", "dbo.Pretensions");
            DropForeignKey("dbo.PersonInChats", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInChats", "Chat_ChatId", "dbo.Chats");
            DropForeignKey("dbo.Chats", "Person_PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInDeals", "Deal_DealId", "dbo.Deals");
            DropForeignKey("dbo.Deals", "Contract_ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Deals", "Campaign_CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Contracts", "Campaign_CampaignId", "dbo.Campaigns");
            DropIndex("dbo.PersonInContracts", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonInContracts", new[] { "Contract_ContractId" });
            DropIndex("dbo.Pictures", new[] { "Product_ProductId" });
            DropIndex("dbo.Pictures", new[] { "Person_PersonId" });
            DropIndex("dbo.Descriptions", new[] { "Product_ProductId" });
            DropIndex("dbo.Products", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonInPretensions", new[] { "Pretension_PretensionId" });
            DropIndex("dbo.PersonInPretensions", new[] { "Person_PersonId" });
            DropIndex("dbo.Pretensions", new[] { "Product_ProductId" });
            DropIndex("dbo.Pretensions", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonInChats", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonInChats", new[] { "Chat_ChatId" });
            DropIndex("dbo.Chats", new[] { "Role_RoleId" });
            DropIndex("dbo.Chats", new[] { "Pretension_PretensionId" });
            DropIndex("dbo.Chats", new[] { "Person_PersonId" });
            DropIndex("dbo.People", new[] { "Role_RoleId" });
            DropIndex("dbo.PersonInDeals", new[] { "Person_PersonId" });
            DropIndex("dbo.PersonInDeals", new[] { "Deal_DealId" });
            DropIndex("dbo.Deals", new[] { "Product_ProductId" });
            DropIndex("dbo.Deals", new[] { "Contract_ContractId" });
            DropIndex("dbo.Deals", new[] { "Campaign_CampaignId" });
            DropIndex("dbo.Contracts", new[] { "Campaign_CampaignId" });
            DropTable("dbo.PersonInContracts");
            DropTable("dbo.Roles");
            DropTable("dbo.Pictures");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Products");
            DropTable("dbo.PersonInPretensions");
            DropTable("dbo.Pretensions");
            DropTable("dbo.PersonInChats");
            DropTable("dbo.Chats");
            DropTable("dbo.People");
            DropTable("dbo.PersonInDeals");
            DropTable("dbo.Deals");
            DropTable("dbo.Contracts");
            DropTable("dbo.Campaigns");
        }
    }
}
