using CrawlerDotnet.Data.Attributes;
using CrawlerDotnet.Data.Models;
using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawlerDotnet.Processor
{
    public class DotnetCrawlerProcessor<T> : IDotnetCrawlerProcessor<T> where T : Entity
    {
        public async Task<IEnumerable<T>> Process(HtmlDocument document)
        {
            var nameValueDictionary = GetColumnNameValuePairsFromHtml(document);

            var processorEntity = ReflectionHelper.CreateNewEntity<T>();
            foreach (var pair in nameValueDictionary)
            {
                ReflectionHelper.TrySetProperty(processorEntity, pair.Key, pair.Value);
            }

            return new List<T>
            {
                processorEntity as T
            };
        }

        private static Dictionary<string, object> GetColumnNameValuePairsFromHtml(HtmlDocument document)
        {
            var columnNameValueDictionary = new Dictionary<string, object>();

            var entityExpression = ReflectionHelper.GetEntityExpression<T>();
            var propertyExpressions = ReflectionHelper.GetPropertyAttributes<T>();

            var entityNode = document.DocumentNode.SelectSingleNode(entityExpression);

            foreach (var expression in propertyExpressions)
            {
                var columnName = expression.Key;
                object columnValue = null;
                var fieldExpression = expression.Value.Item2;

                switch (expression.Value.Item1)
                {
                    case ESelectorType.XPath:
                        var node = entityNode.SelectSingleNode(fieldExpression);
                        if (node != null)
                            columnValue = node.InnerText;
                        break;
                    case ESelectorType.CssSelector:
                        var nodeCss = entityNode.QuerySelector(fieldExpression);
                        if (nodeCss != null)
                            columnValue = nodeCss.InnerText;
                        break;
                    case ESelectorType.FixedValue:
                        if (Int32.TryParse(fieldExpression, out var result))
                        {
                            columnValue = result;
                        }
                        break;
                    default:
                        break;
                }
                columnNameValueDictionary.Add(columnName, columnValue);
            }

            return columnNameValueDictionary;
        }
    }
}