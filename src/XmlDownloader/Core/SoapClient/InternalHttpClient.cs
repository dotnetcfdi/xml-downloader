using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Builder;

namespace XmlDownloader.Core.SoapClient
{
    public static class InternalHttpClient
    {
        private static readonly HttpClient httpClient = new HttpClient();


        public static async Task<InternalResponse> SendAsync(InternalRequest internalRequest)
        {
            var internalResponse = new InternalResponse();

            try
            {
                if (internalRequest.HttpRequestMessage is not null)
                {
                    internalResponse.HttpResponseMessage = await httpClient.SendAsync(
                        internalRequest.HttpRequestMessage,
                        HttpCompletionOption.ResponseHeadersRead);


                    internalResponse =
                        await HttpMessageBuilder.BuildHttpResponseMessage(internalRequest, internalResponse);


                    return internalResponse;
                }
            }
            catch (Exception ex)
            {
                internalResponse.HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                internalResponse.HttpResponseMessage.Content = new StringContent(ex.Message);
            }

            return internalResponse;
        }
    }
}