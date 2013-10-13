using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recommend.Core.Models;

namespace Recommend.Core.DAL
{
    [Obsolete]
    public class RecommendationsInitializer : 
        //DropCreateDatabaseAlways<RecommendationsContext>
        DropCreateDatabaseIfModelChanges<RecommendationsContext>
    {
        protected override void Seed(RecommendationsContext context)
        {
           // SeedMembership();

            var users = new List<User>
                {
                    new User("adam", "test@test.pl")
                };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var recommendations = new List<Recommendation>
                {
                    new Recommendation(1, "I recommend this", new DateTime(2013, 12, 12)) 
                    { Link = "http://teatrstudio.pl/spektakle/42,o%C5%BCenek/" },
                    new Recommendation(1, "This is a test", null)
                };

            recommendations.ForEach(r => context.Recommendations.Add(r));
            context.SaveChanges();
        }

        //private void SeedMembership()
        //{
        //    WebSecurity.InitializeDatabaseConnection(
        //       connectionStringName: "DefaultConnection",
        //       userTableName: "User",
        //       userIdColumn: "Id",
        //       userNameColumn: "UserName",
        //       autoCreateTables: true);
        //}
    }
}
