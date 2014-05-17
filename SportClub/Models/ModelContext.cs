using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportClub.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<SportHalls> SportHalls { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }  // добавляем таблицу ролей
        public DbSet<Role> Roles { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<PhytobarProducts> PhytobarProducts { get; set; }
    }
}