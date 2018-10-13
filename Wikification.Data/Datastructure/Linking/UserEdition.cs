namespace Wikification.Data.Datastructure.Linking
{
    public class UserEdition
    {
        public Edition Edition { get; set; }
        public int EditionId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
