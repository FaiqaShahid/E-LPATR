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
        public DbSet<User> Users { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Issues> Issues { get; set; }
        public DbSet<PackagePlan> PackagePlans { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileStatus> ProfileStatus { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestMessage> RequestMessages { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Degree> Degrees { get; set; }

    }
}