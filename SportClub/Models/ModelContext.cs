using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SportClub.Models.Blog;

namespace SportClub.Models
{
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("DefaultConnection")
        {

        }
        #region Site

        public DbSet<Client> Clients { get; set; }//клієнти
        public DbSet<Trainer> Trainers { get; set; }// тренера
        public DbSet<Accounting> Accountings { get; set; }//платежі
        public DbSet<Ticket> Tickets { get; set; }//абонементи
        public DbSet<SportHalls> SportHalls { get; set; }//зали

        public DbSet<UserProfile> UserProfiles { get; set; }//юзер      
        public DbSet<Discounts> Discounts { get; set; }// знижки
        public DbSet<PhytobarProducts> PhytobarProducts { get; set; }
        public DbSet<Visits> Visits { get; set; }//відвідування
        public DbSet<UploadFile> UploadFile { get; set; }
        #endregion

        #region Blog

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        #endregion
    }
}