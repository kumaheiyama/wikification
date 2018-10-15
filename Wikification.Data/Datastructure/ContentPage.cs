﻿using System;
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

        //Properties
        public Badge Badge { get; private set; }
        public int? BadgeId { get; set; }
        public ICollection<PageCategory> Categories { get; private set; }
        public string Contents { get { return LatestEdition().ParsedContents(); } }
        public ICollection<Edition> Editions { get; private set; }
        public string ExternalId { get; private set; }
        public int Id { get; set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public string Title { get; set; }

        //Methods
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
            var pageCategory = Categories.FirstOrDefault(x => x.CategoryId == category.Id && x.PageId == this.Id);
            if (pageCategory != null)
            {
                Categories.Remove(pageCategory);
            }
        }
        public void SetBadge(Badge badge)
        {
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
