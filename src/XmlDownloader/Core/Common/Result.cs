using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Core.Common
{
    public abstract class Result
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }

    }

    
}