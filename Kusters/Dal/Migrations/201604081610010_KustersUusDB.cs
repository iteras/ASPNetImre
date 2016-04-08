namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KustersUusDB : DbMigration
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
                        CampaignId = c.Int(),
                        Content = c.String(),
                        Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.DealInContracts",
                c => new
                    {
                        DealInContractId = c.Int(nullable: false, identity: true),
                        DealId = c.Int(),
                        ContractId = c.Int(),
                    })
                .PrimaryKey(t => t.DealInContractId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .Index(t => t.DealId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                        DealDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DealId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.DealInCampaigns",
                c => new
                    {
                        DealInCampaignId = c.Int(nullable: false, identity: true),
                        DealId = c.Int(),
                        Deal = c.Int(nullable: false),
                        CampaignId = c.Int(),
                        Campaign = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealInCampaignId)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId)
                .Index(t => t.DealId)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.PersonInDeals",
                c => new
                    {
                        PersonInDealId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        DealId = c.Int(),
                        Date = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.PersonInDealId)
                .ForeignKey("dbo.Deals", t => t.DealId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.DealId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
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
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PersonInChats",
                c => new
                    {
                        PersonInChatId = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(),
                        PersonId = c.Int(),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.PersonInChatId)
                .ForeignKey("dbo.Chats", t => t.ChatId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.ChatId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Message = c.String(maxLength: 255),
                        DateTime = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.ChatId);
            
            CreateTable(
                "dbo.ChatInPretensions",
                c => new
                    {
                        ChatInPretensionId = c.Int(nullable: false, identity: true),
                        ChatId = c.Int(),
                        PretensionId = c.Int(),
                    })
                .PrimaryKey(t => t.ChatInPretensionId)
                .ForeignKey("dbo.Chats", t => t.ChatId)
                .ForeignKey("dbo.Pretensions", t => t.PretensionId)
                .Index(t => t.ChatId)
                .Index(t => t.PretensionId);
            
            CreateTable(
                "dbo.Pretensions",
                c => new
                    {
                        PretensionId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PretensionId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PersonInPretensions",
                c => new
                    {
                        PersonInPretensionId = c.Int(nullable: false, identity: true),
                        PretensionId = c.Int(),
                        PersonId = c.Int(),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.PersonInPretensionId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .ForeignKey("dbo.Pretensions", t => t.PretensionId)
                .Index(t => t.PretensionId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Title = c.String(maxLength: 128),
                        Content = c.String(maxLength: 1024),
                        Price = c.Double(nullable: false),
                        TrackingCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DescriptionId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Location = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Title = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.PersonInContracts",
                c => new
                    {
                        PersonInContractId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        ContractId = c.Int(),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.PersonInContractId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        From = c.String(maxLength: 32),
                        Until = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealInCampaigns", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.People", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.PersonInDeals", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInContracts", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInContracts", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.PersonInChats", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonInChats", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Pretensions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Pictures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "PersonId", "dbo.People");
            DropForeignKey("dbo.Descriptions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Deals", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PersonInPretensions", "PretensionId", "dbo.Pretensions");
            DropForeignKey("dbo.PersonInPretensions", "PersonId", "dbo.People");
            DropForeignKey("dbo.ChatInPretensions", "PretensionId", "dbo.Pretensions");
            DropForeignKey("dbo.ChatInPretensions", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.PersonInDeals", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealInContracts", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealInCampaigns", "DealId", "dbo.Deals");
            DropForeignKey("dbo.DealInContracts", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "CampaignId", "dbo.Campaigns");
            DropIndex("dbo.PersonInContracts", new[] { "ContractId" });
            DropIndex("dbo.PersonInContracts", new[] { "PersonId" });
            DropIndex("dbo.Pictures", new[] { "ProductId" });
            DropIndex("dbo.Descriptions", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "PersonId" });
            DropIndex("dbo.PersonInPretensions", new[] { "PersonId" });
            DropIndex("dbo.PersonInPretensions", new[] { "PretensionId" });
            DropIndex("dbo.Pretensions", new[] { "ProductId" });
            DropIndex("dbo.ChatInPretensions", new[] { "PretensionId" });
            DropIndex("dbo.ChatInPretensions", new[] { "ChatId" });
            DropIndex("dbo.PersonInChats", new[] { "PersonId" });
            DropIndex("dbo.PersonInChats", new[] { "ChatId" });
            DropIndex("dbo.People", new[] { "RoleId" });
            DropIndex("dbo.PersonInDeals", new[] { "DealId" });
            DropIndex("dbo.PersonInDeals", new[] { "PersonId" });
            DropIndex("dbo.DealInCampaigns", new[] { "CampaignId" });
            DropIndex("dbo.DealInCampaigns", new[] { "DealId" });
            DropIndex("dbo.Deals", new[] { "ProductId" });
            DropIndex("dbo.DealInContracts", new[] { "ContractId" });
            DropIndex("dbo.DealInContracts", new[] { "DealId" });
            DropIndex("dbo.Contracts", new[] { "CampaignId" });
            DropTable("dbo.Roles");
            DropTable("dbo.PersonInContracts");
            DropTable("dbo.Pictures");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Products");
            DropTable("dbo.PersonInPretensions");
            DropTable("dbo.Pretensions");
            DropTable("dbo.ChatInPretensions");
            DropTable("dbo.Chats");
            DropTable("dbo.PersonInChats");
            DropTable("dbo.People");
            DropTable("dbo.PersonInDeals");
            DropTable("dbo.DealInCampaigns");
            DropTable("dbo.Deals");
            DropTable("dbo.DealInContracts");
            DropTable("dbo.Contracts");
            DropTable("dbo.Campaigns");
        }
    }
}
