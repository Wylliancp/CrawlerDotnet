using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Models
{
    public class Order : Entity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string BuyerId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string ShipToAddressCity { get; set; }
        public string ShipToAddressCountry { get; set; }
        public string ShipToAddressState { get; set; }
        public string ShipToAddressStreet { get; set; }
        public string ShipToAddressZipCode { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
