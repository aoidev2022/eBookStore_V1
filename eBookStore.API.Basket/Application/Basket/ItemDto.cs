using eBookStore.API.Basket.Clients.Book;

using System;

namespace eBookStore.API.Basket.Application.Basket
{
    public class ItemDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int BookId { get; set; }
        public int PurchasedPrice { get; set; }

        public Book BookDetails { get; set; }
    }
}
