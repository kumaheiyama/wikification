using Microsoft.EntityFrameworkCore;
using Wikification.Data.Datastructure;

namespace Wikification.Data
{
    internal class MainContextSeeder
    {
        private MainContextSeeder()
        {

        }
        public static void Seed(ModelBuilder builder)
        {
            SeedBadges(builder);
            SeedLevels(builder);
        }

        private static void SeedLevels(ModelBuilder builder)
        {
            //builder.Entity<Level>().HasData(
            //    new Level { Id = 1, Name = "Egg", XpThreshold = 0 },
            //    new Level { Id = 2, Name = "Larva", XpThreshold = 336 },
            //    new Level { Id = 3, Name = "Pupa", XpThreshold = 1129 },
            //    new Level { Id = 4, Name = "Butterfly", XpThreshold = 3793 },
            //    new Level { Id = 5, Name = "Dragonfly", XpThreshold = 12746 }
            //);
        }

        private static void SeedBadges(ModelBuilder builder)
        {
            //builder.Entity<Badge>().HasData(
            //    new Badge { AwardedXp = 100, Description = "'First page' is awarded when the first page is read. Good work!", Id = 1, Name = "First page", SymbolUrl = "http://image1" },
            //    new Badge { AwardedXp = 100, Description = "'Ten pages' is awarded when ten pages have been read. Fantastic!", Id = 2, Name = "Ten pages", SymbolUrl = "http://image2" },
            //    new Badge { AwardedXp = 500, Description = "'Hundred pages' is awarded when one hundred pages have been read. Amazing!", Id = 3, Name = "Hundred pages", SymbolUrl = "http://image3" }
            //);
        }
    }
}
