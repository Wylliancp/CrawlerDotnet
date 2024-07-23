using CrawlerDotnet.Data.Attributes;

namespace CrawlerDotnet.Data.Models
{
    [DotnetCrawlerEntity(XPath = "//*[@id='LeftSummaryPanel']/div[1]")]
    public partial class Catalog : Entity
    {
        [DotnetCrawlerField(Expression = "1", SelectorType = ESelectorType.FixedValue)]
        public int CatalogBrandId { get; set; }
        [DotnetCrawlerField(Expression = "1", SelectorType = ESelectorType.FixedValue)]
        public int CatalogTypeId { get; set; }
        public string Description { get; set; }
        [DotnetCrawlerField(Expression = "//*[@id='itemTitle']/text()", SelectorType = ESelectorType.XPath)]
        public string Name { get; set; }
        public string PictureUri { get; set; }
        public decimal Price { get; set; }

        public virtual Brand CatalogBrand { get; set; }
        public virtual Type CatalogType { get; set; }
    }
}

