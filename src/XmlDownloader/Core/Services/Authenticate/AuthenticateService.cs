using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Models;
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


        public async Task<Token> Authenticate()
        {
            var tokenPeriod = TokenPeriod.Create();

            var soapEnvelope = soapEnvelopeBuilder.Authenticate(tokenPeriod);

            var envelope = Helper.CleanXml(soapEnvelope);


            File.WriteAllText("Request.xml", soapEnvelope);

            var endpoint = Helper.GetAuthenticateEndPoint();


            var internalRequest = new InternalRequest
            {
                Url = endpoint.Url,
                SoapAction = endpoint.SoapAction,
                SoapEnvelope = soapEnvelope,
                HttpMethod = HttpMethod.Post,
                EndPointName = EndPointName.Authenticate,
            };

            internalRequest.HttpRequestMessage = HttpMessageBuilder.BuildHttpRequestMessage(internalRequest);

            var internalResponse = await InternalHttpClient.SendAsync(internalRequest);

            var token = Helper.GetTokenByRawResponse(internalResponse.ResponseAsString);

            return token;
        }
    }
}