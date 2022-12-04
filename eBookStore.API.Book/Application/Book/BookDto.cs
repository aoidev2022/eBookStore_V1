namespace eBookStore.API.Book.Application.Book
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}
