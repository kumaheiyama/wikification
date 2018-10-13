using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class ContentPage : IEntity
    {
        public ContentPage()
        {
            Editions = new List<Edition>();
            Categories = new List<Category>();
            Badges = new List<Badge>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get { return LatestEdition().ParsedContents(); } }
        public ICollection<Edition> Editions { get; private set; }
        public ICollection<Category> Categories { get; private set; }
        public ICollection<Badge> Badges { get; private set; }

        public Edition LatestEdition()
        {
            var latestEdition = Editions.OrderByDescending(x => x.Version.ToString()).FirstOrDefault();
            return latestEdition;
        }
        public void AddEdition(Edition edition)
        {
            var version = edition.Version.ToString();
            if (!Editions.Select(x => x.Version.ToString()).Contains(version))
            {
                Editions.Add(edition);
            }
        }
        public void AddCategory(Category category)
        {
            if (!Categories.Contains(category)) {
                Categories.Add(category);
            }
        }
        public void RemoveCategory(Category category)
        {
            if (Categories.Contains(category))
            {
                Categories.Remove(category);
            }
        }
        public void AddBadge(Badge badge)
        {
            if (!Badges.Contains(badge))
            {
                Badges.Add(badge);
            }
        }
        public void RemoveBadge(Badge badge)
        {
            if(Badges.Contains(badge))
            {
                Badges.Remove(badge);
            }
        }

        public int CalculatedAwardedXp()
        {
            var calculatedXp = Editions.Sum(x => x.CalculatedAwardedXp());
            return calculatedXp;
        }
    }
}
