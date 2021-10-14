using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Activities.Any())
            {
                return;
            }

            var activities = new List<Activity>()
            {
                new Activity()
                {
                    Title = "Activity 1",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "ACtivity two months ago",
                    Category = "Category 1",
                    Venue = "UK",
                    City = "London"
                },
                new Activity()
                {
                    Title = "Activity 2",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "ACtivity one months ago",
                    Category = "Category 2",
                    Venue = "US",
                    City = "Washington DC"
                },

            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}