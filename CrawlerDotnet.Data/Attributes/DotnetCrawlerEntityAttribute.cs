using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Data.Attributes
{
    public class DotnetCrawlerEntityAttribute : Attribute
    {
        public string XPath { get; set; }
    }
}
