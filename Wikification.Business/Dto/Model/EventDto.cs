namespace Wikification.Business.Dto.Model
{
    public class EventDto
    {
        public int Id { get; set; }
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
            LevelEarned,
            LevelRemoved,
            XpEarned,
            UserAdded,
            UserRemoved
        }
    }
}
