using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Core.Common
{
    public interface IHasSuccessResponse
    {
        public bool IsSuccess { get; set; }
    }
}