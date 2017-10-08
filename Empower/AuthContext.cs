using Empower.Entities;
using Empower.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            
        }
        public DbSet<Client> Clients { get; set; }
    }
}