using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommend.Core.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Recommend.Core.DAL
{
    public class RecommendationsContext : DbContext
    {
        public RecommendationsContext() : base("DefaultConnection") {}

        public RecommendationsContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Place> Places { get; set; }
    }
}
