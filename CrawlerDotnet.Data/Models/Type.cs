using System.Collections.Generic;

namespace CrawlerDotnet.Data.Models
{
    public class Type : Entity
    {

        public Type()
        {
            Catalogs = new HashSet<Catalog>();
        }

        public string Name { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
