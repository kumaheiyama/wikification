using System.Collections.Generic;
using Wikification.Data.Datastructure.Linking;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Category : IEntity
    {
        public Category() { }
        public Category(string name, Badge badge = null) : this()
        {
            Name = name;
            SetBadge(badge);
        }

        //Properties
        public Badge Badge { get; private set; }
        public int? BadgeId { get; set; }
        public int Id { get; set; }
        public string Name { get; private set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public ICollection<PageCategory> Pages { get; set; }

        //Methods
        public void SetBadge(Badge badge)
        {
            if (badge == null) return;
            Badge = badge;
        }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
