
using System.Collections.Generic;

namespace CrawlerDotnet.Data.Models
{
    public class Basket : Entity
    {
        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
        }

        public string BuyerId { get; set; }

        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
