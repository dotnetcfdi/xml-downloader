using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
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

            if (internalResponse.InternalRequest?.RawRequest != null)
            {
                await File.WriteAllTextAsync("RawRequest.Xml", internalResponse.InternalRequest.RawRequest);
                await File.WriteAllTextAsync("RawResponse.Xml", internalResponse.RawResponse);
            }

          


            var token = Helper.GetTokenByRawResponse(internalResponse.RawResponse);

            return token;
        }
    }
}