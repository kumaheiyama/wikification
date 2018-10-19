namespace Wikification.Data.Interfaces
{
    public interface IAwardedXp
    {
        int AwardedXp { get; }
        int CalculatedAwardedXp();
        void SetAwardedXp(int xp);
    }
}
