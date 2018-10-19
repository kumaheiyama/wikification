using Microsoft.EntityFrameworkCore;

namespace Wikification.Data.Datastructure
{
    public partial class Edition
    {
        [Owned]
        public class EditionVersion
        {
            public EditionVersion()
            {
                Major = 1;
                Minor = 0;
                Change = 0;
            }
            public EditionVersion(int major, int minor, int change) : this()
            {
                Major = major;
                Minor = minor;
                Change = change;
            }

            //Properties
            public int Major { get; private set; }
            public int Minor { get; private set; }
            public int Change { get; private set; }

            //Methods
            public void IncreaseVersion(VersionUpdate versionUpdate)
            {
                switch (versionUpdate)
                {
                    case VersionUpdate.Major:
                        Major += 1;
                        break;
                    case VersionUpdate.Minor:
                        Minor += 1;
                        break;
                    default:
                    case VersionUpdate.Change:
                        Change += 1;
                        break;
                }
            }
            public override string ToString()
            {
                return this.Major + "." + this.Minor + "." + this.Change;
            }
        }
        public enum VersionUpdate
        {
            Major,
            Minor,
            Change
        }
    }

}
