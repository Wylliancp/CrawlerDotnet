using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Models
{
    public class OrderItem : Entity
    {

        public int? OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Units { get; set; }
        public int ItemOrderedCatalogItemId { get; set; }
        public string ItemOrderedPictureUri { get; set; }
        public string ItemOrderedProductName { get; set; }

        public virtual Order Order { get; set; }
    }
}
