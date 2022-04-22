using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Builder
{
    public static class HttpMessageBuilder
    {
        public static HttpRequestMessage BuildHttpRequestMessage(InternalRequest internalRequest)
        {
            var content = new StringContent(
                internalRequest.SoapEnvelope,
                internalRequest.Encoding,
                internalRequest.MediaType);


            var request = new HttpRequestMessage(
                internalRequest.HttpMethod,
                internalRequest.Url);

            request.Headers.Add("SOAPAction", internalRequest.SoapAction);
            request.Content = content;

            return request;
        }

      

        public static async Task<InternalResponse> BuildHttpResponseMessage(InternalRequest internalRequest,
            InternalResponse internalResponse)
        {
            if (internalResponse.HttpResponseMessage == null) return internalResponse;

            internalResponse.IsSuccessStatusCode = internalResponse.HttpResponseMessage.IsSuccessStatusCode;
            internalResponse.IsSuccessStatusCode = internalResponse.HttpResponseMessage.IsSuccessStatusCode;
            internalResponse.ReasonPhrase = internalResponse.HttpResponseMessage.ReasonPhrase;
            internalResponse.ResponseAsString =
                await internalResponse.HttpResponseMessage.Content.ReadAsStringAsync();
            internalResponse.HttpStatusCode = internalResponse.HttpResponseMessage.StatusCode;
            internalResponse.HttpRequestMessage = internalResponse.HttpResponseMessage.RequestMessage;
            internalResponse.HttpResponseMessage = internalResponse.HttpResponseMessage;
            internalResponse.EndPointName = internalRequest.EndPointName;

            return internalResponse;
        }
    }
}