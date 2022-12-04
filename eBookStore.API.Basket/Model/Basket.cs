using System;
using System.Collections.Generic;

namespace eBookStore.API.Basket.Model
{
    public class Basket
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public BasketStatusEnum Status { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
