using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class LearnContext : DbContext
    {
        public LearnContext() : base("con")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<AccountStatus> AccountStatus { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<DelieveredRequest> DelieveredRequest { get; set; }
        public DbSet<Earning> Earning { get; set; }
        public DbSet<EarningStatus> EarningStatus { get; set; }
        public DbSet<Issues> Issues { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<PackagePlan> PackagePlan { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestMessage> RequestMessage { get; set; }
        public DbSet<RequestStatus> RequestStatus { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }

        public System.Data.Entity.DbSet<E_LPATR.Models.Teacher> Teachers { get; set; }

        public System.Data.Entity.DbSet<E_LPATR.Models.TeachersRequests> TeachersRequests { get; set; }
    }
}