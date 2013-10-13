using System.Collections.Generic;
using Recommend.Core.Models;
using WebMatrix.WebData;

namespace Recommend.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Recommend.Core.DAL;
    using System.Data.Spatial;

    internal sealed class Configuration : DbMigrationsConfiguration<RecommendationsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RecommendationsContext context)
        {
            var users = new List<User>
                {
                    new User("adam", "test@test.pl") {Id = 2}
                };

            users.ForEach(u => context.Users.AddOrUpdate(
                x => x.UserName,
                u));

            var places = new List<Place>
                {
                    new Place
                        {
                            Id = 1,
                            UserId = 2,
                            AddedBy = users[0],
                            Description = "tesdsdsdsdst",
                            Name = "tesdsdsdsdst",
                            Link = "http://www.google.pl",
                            Location = DbGeography.FromText("POINT(-122.335197 47.646711)")
                        }
                };

            var recommendations = new List<Recommendation>
                {
                    new Recommendation(2, "I recommend this", new DateTime(2013, 12, 12))
                        {
                            Link = "http://teatrstudio.pl/spektakle/42,o%C5%BCenek/",
                            Place = places[0],
                            PlaceId = 1,
                            User = users[0]
                        },
                    new Recommendation(2, "This is a test", null)
                        {
                            Place = places[0],
                            PlaceId = 1,
                            User = users[0]
                        }
                };

            recommendations.ForEach(r => context.Recommendations.AddOrUpdate(
                x => x.Description,
                r));
        }
    }
}
