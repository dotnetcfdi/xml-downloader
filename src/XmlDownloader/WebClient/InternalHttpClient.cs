using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.WebClient
{
    internal class InternalHttpClient
    {
        private static readonly HttpClient httpClient = new HttpClient();


        public static async Task<HttpResponseMessage> SendAsync(InternalRequest InternalRequest)
        {
            try
            {
                using var request = BuildHttpRequestMessage(InternalRequest);

                using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                var responseAsString = await response.Content.ReadAsStringAsync();

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        private static HttpRequestMessage BuildHttpRequestMessage(InternalRequest internalRequest)
        {
            var content = new StringContent(internalRequest.SoapEnvelopeXml, internalRequest.Encoding,
                internalRequest.MediaType);

            var request = new HttpRequestMessage(internalRequest.HttpMethod, internalRequest.Url);

            request.Headers.Add("SOAPAction", internalRequest.SoapAction);
            request.Content = content;

            return request;
        }
    }
}