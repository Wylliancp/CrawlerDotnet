using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotnet.Downloader
{
    public enum DotnetCrawlerDownloaderType
    {
        /// <summary>
        /// Download to local file
        /// </summary>
        FromFile,
        /// <summary>
        /// Without downloading to local file, download temp and directly use
        /// </summary>
        FromMemory,
        /// <summary>
        /// Read direct from web
        /// </summary>
        FromWeb
    }
}
