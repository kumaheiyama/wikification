using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class ContentPage : IEntity
    {
        public ContentPage()
        {
            Categories = new List<PageCategory>();
            Editions = new List<Edition>();
        }
        public ContentPage(string title) : this()
        {
            Title = title;
        }
        public ContentPage(string title, Edition firstEdition) : this(title)
        {
            AddEdition(firstEdition);
        }

        //Properties
        public Badge Badge { get; private set; }
        public int? BadgeId { get; set; }
        public ICollection<PageCategory> Categories { get; private set; }
        public string Contents { get { return LatestEdition().Contents; } }
        public ICollection<Edition> Editions { get; private set; }
        public string ExternalId { get; private set; }
        public int Id { get; set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public string ParsedContents { get { return LatestEdition().ParsedContents(); } }
        public string Title { get; set; }

        //Methods
        public Edition LatestEdition()
        {
            var latestEdition = Editions.OrderByDescending(x => x.Version.ToString()).FirstOrDefault();
            return latestEdition;
        }
        public void AddEdition(Edition edition)
        {
            if (edition == null) return;
            var version = edition.Version.ToString();
            if (!Editions.Select(x => x.Version.ToString()).Contains(version))
            {
                Editions.Add(edition);
            }
        }
        public void AddCategory(Category category)
        {
            if (category == null) return;
            if (!Categories.Any(x => x.CategoryId == category.Id && x.PageId == this.Id))
            {
                Categories.Add(new PageCategory
                {
                    Category = category,
                    Page = this
                });
            }
        }
        public void RemoveCategory(Category category)
        {
            if (category == null) return;
            var pageCategory = Categories.FirstOrDefault(x => x.CategoryId == category.Id && x.PageId == this.Id);
            if (pageCategory != null)
            {
                Categories.Remove(pageCategory);
            }
        }
        public void SetBadge(Badge badge)
        {
            if (badge == null) return;
            Badge = badge;
        }
        public void SetExternalId(string externalId)
        {
            ExternalId = externalId;
        }
        public int CalculatedAwardedXp()
        {
            var calculatedXp = Editions.Sum(x => x.CalculatedAwardedXp());
            return calculatedXp;
        }
    }
}
