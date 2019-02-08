using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Cards.Models;

namespace Cards.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var set1 = new Set()
            {
                Name = "Set1",
                Description = "It a set"
            };

            var set2 = new Set()
            {
                Name = "Set2",
                Description = "It another set"
            };

            var set3 = new Set()
            {
                Name = "Set3",
                Description = "It yet another set"
            };

            var set4 = new Set()
            {
                Name = "Set4",
                Description = "Surprise, it a set"
            };

            context.Sets.Add(set1);
            context.Sets.Add(set2);
            context.Sets.Add(set3);
            context.Sets.Add(set4);

            context.SaveChanges();
        }
    }
}