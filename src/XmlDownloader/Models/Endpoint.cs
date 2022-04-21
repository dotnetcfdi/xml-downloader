using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Common;

namespace XmlDownloader.Models
{
    internal class Endpoint
    {
        public EndPointName EndPointName { get; set; }
        public EndPointType EndPointType { get; set; }
        public string? Url { get; set; }
        public string? Action { get; set; }
    }
}