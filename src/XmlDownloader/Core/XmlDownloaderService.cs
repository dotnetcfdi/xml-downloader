using Credencials.Core;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Services.Authenticate;
using XmlDownloader.Core.Services.Query;

namespace XmlDownloader.Core;

public class XmlDownloaderService
{
    private readonly ICredential credential;
    private readonly SoapEnvelopeBuilder soapEnvelopeBuilder;

    public Token? Token { get; set; }

    public XmlDownloaderService(ICredential credential, Token? token = null)
    {
        this.credential = credential;
        this.soapEnvelopeBuilder = new SoapEnvelopeBuilder(credential);

        if (token is not null)
            Token = token;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns>Token</returns>
    public async Task<Token> GetCurrentToken()
    {
        if (Token is null || !Token.IsValid())
            Token = await Authenticate();

        return Token;
    }

    public async Task<Token> Authenticate()
    {
        var service = new AuthenticateService(soapEnvelopeBuilder);
        var token = await service.Authenticate();

        return token;
    }

    public async Task<QueryResult> Query()
    {
        var service = new QueryService(soapEnvelopeBuilder);


        var queryParameters = new QueryParameters();
        queryParameters.StartDate = new DateTime(2018, 12, 01, 0, 0, 0);
        queryParameters.EndDate = new DateTime(2018, 12, 02, 23, 59, 59);
        queryParameters.EmitterRfc = null;
        queryParameters.ReceiverRfc = "DGE131017IP1";
        queryParameters.RequestType = RequestType.CFDI;
        queryParameters.DownloadType = DownloadType.Received;


        var queryResult = await service.Query(
            queryParameters.StartDate.ToSatFormat(),
            queryParameters.EndDate.ToSatFormat(),
            queryParameters.EmitterRfc,
            queryParameters.ReceiverRfc,
            queryParameters.RequestType.ToString(),
            queryParameters.DownloadType.ToString()
        );



        return queryResult;
    }
}