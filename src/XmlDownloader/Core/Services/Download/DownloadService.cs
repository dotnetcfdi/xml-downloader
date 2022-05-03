using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Services.Authenticate;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Download
{
    public class DownloadService
    {
        private readonly SoapEnvelopeBuilder soapEnvelopeBuilder;

        public DownloadService(SoapEnvelopeBuilder soapEnvelopeBuilder)
        {
            this.soapEnvelopeBuilder = soapEnvelopeBuilder;
        }

        public async Task<DownloadResult> Download(string packageId, AuthenticateResult token)
        {
            var rawRequest = soapEnvelopeBuilder.BuildDownload(packageId);


            var endpoint = Helper.GetDownloadEndPoint();


            var internalRequest = new InternalRequest
            {
                Url = endpoint.Uri,
                SoapAction = endpoint.SoapAction,
                RawRequest = rawRequest,
                HttpMethod = HttpMethod.Post,
                EndPointName = endpoint.EndPointName,
                Token = token
            };


            var internalResponse = await InternalHttpClient.SendAsync(internalRequest);


            await File.WriteAllTextAsync($"{internalResponse.EndPointName}-Request.xml",
                internalResponse?.InternalRequest?.RawRequest);
            await File.WriteAllTextAsync($"{internalResponse?.EndPointName}-Response.xml",
                internalResponse?.RawResponse);


            var result = Helper.GetDownloadResult(packageId, internalResponse?.RawResponse);


            return result;
        }
    }
}