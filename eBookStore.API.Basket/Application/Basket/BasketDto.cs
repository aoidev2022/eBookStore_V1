using System;
using System.Collections.Generic;

namespace eBookStore.API.Basket.Application.Basket
{
    public class BasketDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public virtual ICollection<ItemDto> Items { get; set; }
    }
}
