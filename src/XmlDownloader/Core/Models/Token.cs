using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Core.Models
{
    public class Token
    {
        
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Value { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
