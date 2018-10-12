namespace Wikification.Data.Interfaces
{
    public interface IAwardedXp
    {
        int AwardedXp { get; set; }
        int CalculatedAwardedXp();
    }
}
