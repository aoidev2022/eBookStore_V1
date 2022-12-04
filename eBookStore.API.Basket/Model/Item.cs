using System;

namespace eBookStore.API.Basket.Model
{
    public class Item
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int BookId { get; set; }
        public int PurchasedPrice { get; set; }

        public virtual int BasketId { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
