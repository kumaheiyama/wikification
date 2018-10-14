using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Level : IEntity
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public int XpThreshold { get; set; }
    }
}
