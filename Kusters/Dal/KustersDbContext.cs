using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Migrations;
using Domain;


namespace Dal
{
    public class KustersDbContext : DbContext
    {
        public KustersDbContext() : base("DbConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KustersDbContext,MigrationConfiguration>());
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<PersonInChat> PersonInChats { get; set; }
        public DbSet<PersonInContract> PersonInContracts { get; set; }
        public DbSet<PersonInDeal> PersonInDeals { get; set; }
        public DbSet<PersonInPretension> PersonInPretensions { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Pretension> Pretensions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
