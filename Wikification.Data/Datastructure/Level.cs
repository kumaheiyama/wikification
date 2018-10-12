using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Level : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int XpThreshold { get; set; }
    }
}
