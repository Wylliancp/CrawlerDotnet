using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Models
{
    public class BasketItem : Entity
    {

        public int? BasketId { get; set; }
        public int CatalogItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Basket Basket { get; set; }
    }
}
