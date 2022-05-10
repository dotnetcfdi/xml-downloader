using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Services.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Authenticate
{
    public class AuthenticateService
    {
        private readonly SoapEnvelopeBuilder soapEnvelopeBuilder;

        public AuthenticateService(SoapEnvelopeBuilder soapEnvelopeBuilder)
        {
            this.soapEnvelopeBuilder = soapEnvelopeBuilder;
        }


        public async Task<AuthenticateResult> Authenticate()
        {
            //var date = new DateTime(2022, 4, 25, 19, 0, 0);
            //var tokenPeriod = TokenPeriod.Create(date);

            var rawRequest = soapEnvelopeBuilder.BuildAuthenticate();


            var endpoint = Helper.GetAuthenticateEndPoint();


            var internalRequest = new InternalRequest
            {
                Url = endpoint.Uri,
                SoapAction = endpoint.SoapAction,
                RawRequest = rawRequest,
                HttpMethod = HttpMethod.Post,
                EndPointName = EndPointName.Authenticate,
            };


            var internalResponse = await InternalHttpClient.SendAsync(internalRequest);


            //token
            var result = Helper.GetAuthenticateResult(internalResponse?.RawResponse);
            result.InternalRequest = internalRequest;
            result.InternalResponse = internalResponse;


            return result;
        }
    }
}