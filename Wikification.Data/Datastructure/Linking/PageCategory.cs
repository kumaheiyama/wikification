namespace Wikification.Data.Datastructure.Linking
{
    public class PageCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PageId { get; set; }
        public ContentPage Page { get; set; }
    }
}
