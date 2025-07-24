namespace BookShop.Models
{
    public class BookApiResponse
    {
        public string Error { get; set; } = "";
        public string Total { get; set; } = "";
        public string Page { get; set; } = "";
        public List<Book> Books { get; set; } = new();
    }
}