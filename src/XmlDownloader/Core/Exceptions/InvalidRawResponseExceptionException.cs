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