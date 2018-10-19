using System;
using System.Collections.Generic;
using System.Linq;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class ExternalSystem : IEntity
    {
        public ExternalSystem()
        {
            Badges = new List<Badge>();
            Categories = new List<Category>();
            Events = new List<Event>();
            Levels = new List<Level>();
            Pages = new List<ContentPage>();
            Users = new List<User>();
        }
        public ExternalSystem(string name, string externalId, string callbackUrl) : this()
        {
            Name = name;
            ExternalId = externalId;
            CallbackUrl = callbackUrl;
        }

        //Properties
        public ICollection<Badge> Badges { get; private set; }
        public string CallbackUrl { get; set; }
        public ICollection<Category> Categories { get; private set; }
        public ICollection<Event> Events { get; private set; }
        public string ExternalId { get; set; }
        public int Id { get; set; }
        public ICollection<Level> Levels { get; private set; }
        public string Name { get; set; }
        public ICollection<ContentPage> Pages { get; private set; }
        public ICollection<User> Users { get; private set; }

        //Methods
        public void AddPage(ContentPage page)
        {
            if (page == null) return;
            if (!Pages.Select(x => x.Id).Contains(page.Id)) {
                Pages.Add(page);
            }
        }
        public void AddUser(User user)
        {
            if (user == null) return;
            var existingUser = Users.FirstOrDefault(x => x.ExternalId == user.ExternalId || x.Username == user.Username);
            if (existingUser == null) {
                Users.Add(user);
            }
        }
        public void AddBadge(Badge badge)
        {
            if (badge == null) return;
            Badges.Add(badge);
        }
        public void AddLevel(Level level)
        {
            if (level == null) return;
            Levels.Add(level);
        }
    }
}
