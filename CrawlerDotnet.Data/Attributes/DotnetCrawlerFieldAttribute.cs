using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Attributes
{
    public class DotnetCrawlerFieldAttribute : Attribute
    {
        public string Expression { get; set; }
        public ESelectorType SelectorType { get; set; }
    }
}
