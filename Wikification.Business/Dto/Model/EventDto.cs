namespace Wikification.Business.Dto.Model
{
    public class EventDto
    {
        public string Name { get; set; }
        public long Timestamp { get; set; }
        public EventDtoType Type { get; set; }
        
        public enum EventDtoType
        {
            Other,
            BadgeAdded,
            BadgeEarned,
            BadgeRemoved,
            CategoryAdded,
            CategoryRemoved,
            EditionRead,
            EditionAdded,
            LevelAdded,
            LevelEarned,
            LevelRemoved,
            XpEarned,
            UserAdded,
            UserRemoved
        }
    }
}
