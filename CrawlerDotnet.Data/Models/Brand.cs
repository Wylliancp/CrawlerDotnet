using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Models
{
    public class Brand : Entity
    {
        public Brand()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public string Name { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
