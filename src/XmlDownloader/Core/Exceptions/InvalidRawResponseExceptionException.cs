using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Core.Exceptions
{
    public class InvalidRawResponseExceptionException : Exception
    {
        public InvalidRawResponseExceptionException(Exception exception, string message)
        {

        }
        public InvalidRawResponseExceptionException(string message)
        {

        }

    }
}