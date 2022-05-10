using XmlDownloader.Core.Builder;
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


            var result = Helper.GetDownloadResult(packageId, internalResponse?.RawResponse);
            result.InternalRequest = internalRequest;
            result.InternalResponse = internalResponse;

            return result;
        }
    }
}