using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Builder;

public static class MessageBuilder
{
    public static HttpRequestMessage BuildHttpRequestMessage(InternalRequest internalRequest)
    {
        var content = new StringContent(
            internalRequest.RawRequest ?? string.Empty,
            internalRequest.Encoding,
            internalRequest.MediaType);


        var request = new HttpRequestMessage(
            internalRequest.HttpMethod,
            internalRequest.Url);

        request.Headers.Add("SOAPAction", internalRequest.SoapAction);

        if (internalRequest.Token is not null)
            request.Headers.Add("Authorization", internalRequest.Token.Value);

        request.Content = content;

        return request;
    }


    public static async Task<InternalResponse> BuildInternalResponseMessage(InternalRequest internalRequest,
        HttpResponseMessage response)
    {
        var internalResponse = new InternalResponse
        {
            IsSuccessStatusCode = response.IsSuccessStatusCode,
            ReasonPhrase = response.ReasonPhrase,
            RawResponse = await response.Content.ReadAsStringAsync(),
            HttpStatusCode = response.StatusCode,
            EndPointName = internalRequest.EndPointName,
            InternalRequest = internalRequest
        };


        return internalResponse;
    }
}