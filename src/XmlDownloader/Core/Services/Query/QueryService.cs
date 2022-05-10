using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Services.Authenticate;
using XmlDownloader.Core.Services.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Query
{
    public class QueryService
    {
        private readonly SoapEnvelopeBuilder soapEnvelopeBuilder;

        public QueryService(SoapEnvelopeBuilder soapEnvelopeBuilder)
        {
            this.soapEnvelopeBuilder = soapEnvelopeBuilder;
        }

        public async Task<QueryResult> Query(string startDate, string endDate, string? emitterRfc, string? receiverRfc,
            string requestType, string downloadType, AuthenticateResult token)
        {
            var rawRequest = soapEnvelopeBuilder.BuildQuery(
                startDate,
                endDate,
                requestType,
                downloadType,
                emitterRfc,
                receiverRfc);


            var endpoint = Helper.GetQueryEndPoint();


            var internalRequest = new InternalRequest
            {
                Url = endpoint.Uri,
                SoapAction = endpoint.SoapAction,
                RawRequest = rawRequest,
                HttpMethod = HttpMethod.Post,
                EndPointName = EndPointName.Query,
                Token = token
            };


            var internalResponse = await InternalHttpClient.SendAsync(internalRequest);


            var result = Helper.GetQueryResult(internalResponse?.RawResponse);
            result.InternalRequest = internalRequest;
            result.InternalResponse = internalResponse;

            return result;
        }
    }
}