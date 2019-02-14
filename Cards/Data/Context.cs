using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Cards.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cards.Data
{
    public class Context : IdentityDbContext<IdentityUser>
    {
        public Context()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        
    }

}