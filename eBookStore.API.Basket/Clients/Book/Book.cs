namespace eBookStore.API.Basket.Clients.Book
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}
