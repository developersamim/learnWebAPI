using Empower.Entities;
using Empower.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Empower
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("AuthContext")
        {
            //Disable initializer
            Database.SetInitializer<AuthContext>(null);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Category>().HasOptional(x => x.parent)
                .WithMany(x => x.children)
                .HasForeignKey(x => x.parentId)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
            
        }
    }
}