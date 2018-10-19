using System;
using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Event : IEntity
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; private set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public long Timestamp { get; private set; }
        public EventType Type { get; private set; }

        //Methods
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetTimestamp(long timestamp)
        {
            Timestamp = timestamp;
        }
        public void SetTimestamp(DateTime dateTime)
        {
            if (dateTime == null) return;
            Timestamp = dateTime.ToUniversalTime().Ticks;
        }
        public void SetType(EventType type)
        {
            Type = type;
        }
    }
    public enum EventType
    {
        Other,
        BadgeAdded,
        BadgeEarned,
        BadgeRemoved,
        CategoryAdded,
        CategoryRemoved,
        EditionRead,
        EditionAdded,
        LevelEarned,
        LevelRemoved,
        XpEarned,
        UserAdded,
        UserRemoved,
        LevelAdded
    }
}
