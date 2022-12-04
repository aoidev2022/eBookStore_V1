using System;

namespace eBookStore.API.Basket.Clients.Author
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
