using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Models
{
    public class Endpoint
    {
        public EndPointName EndPointName { get; set; }
        public EndPointType EndPointType { get; set; }
        public string Url { get; set; } = string.Empty;
        public string SoapAction { get; set; } = string.Empty;
    }
}
