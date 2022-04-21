namespace XmlDownloader.WebClient
{
    public class InternalHttpClientFactory 
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public HttpClient CreateClient(string name)
        {
            return httpClient;
        }

    }
}
