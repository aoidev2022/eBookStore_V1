using eBookStore.API.Gateway.RemoteInterface.Author;

namespace eBookStore.API.Gateway.RemoteInterface.Book
{
    public interface IBookRemote
    {
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }

        public AuthorDto Author { get; set; }
    }
}
