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
            using var request = MessageBuilder.BuildHttpRequestMessage(internalRequest);

            using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseContentRead);


            var internalResponse = await MessageBuilder.BuildInternalResponseMessage(internalRequest, response);





            return internalResponse;
        }
    }
}