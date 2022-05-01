using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
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

        public async Task<QueryResult> Query(string startDate, string endDate, string emitterRfc, string receiverRfc,
            string requestType, string downloadType = "")
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
            };


            var internalResponse = await InternalHttpClient.SendAsync(internalRequest);


            File.WriteAllText($"{internalResponse.EndPointName}-Request.xml", internalResponse.InternalRequest.RawRequest);
            File.WriteAllText($"{internalResponse.EndPointName}-Response.xml", internalResponse.RawResponse);

            return new QueryResult();
        }
    }
}