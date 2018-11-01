using Wikification.Data.Interfaces;

namespace Wikification.Data.Datastructure
{
    public class Level : IEntity
    {
        public Level(string name, int xpThreshold)
        {
            Name = name;
            XpThreshold = xpThreshold;
        }

        //Properties
        public int Id { get; set; }
        public string Name { get; private set; }
        public ExternalSystem System { get; set; }
        public int SystemId { get; set; }
        public int XpThreshold { get; private set; }

        //Methods
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetXpThreshold(int threshold)
        {
            XpThreshold = threshold;
        }
    }
}
