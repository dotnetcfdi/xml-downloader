using Credencials.Core;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Services.Authenticate;
using XmlDownloader.Core.Services.Query;
using XmlDownloader.Core.Services.Verify;

namespace XmlDownloader.Core;

public class XmlDownloaderService
{
    private readonly ICredential credential;
    private readonly SoapEnvelopeBuilder soapEnvelopeBuilder;

    public AuthenticateResult? Token { get; set; }

    public XmlDownloaderService(ICredential credential, AuthenticateResult? token = null)
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
    public async Task<AuthenticateResult> GetCurrentToken()
    {
        if (Token is null || !Token.IsValid())
            Token = await Authenticate();

        return Token;
    }

    public async Task<AuthenticateResult> Authenticate()
    {
        var service = new AuthenticateService(soapEnvelopeBuilder);
        Token = await service.Authenticate();

        return Token;
    }

    public async Task<QueryResult> Query(string startDate, string endDate, string? emitterRfc, string? receiverRfc,
        string requestType, string downloadType, AuthenticateResult token)
    {
        var service = new QueryService(soapEnvelopeBuilder);


        var queryResult = await service.Query(
            startDate,
            endDate,
            emitterRfc,
            receiverRfc,
            requestType,
            downloadType,
            token);


        return queryResult;
    }

    public async Task<QueryResult> Query(string startDate, string endDate, string? emitterRfc, string? receiverRfc,
        string requestType, string downloadType)
    {
        var token = await GetCurrentToken();


        var service = new QueryService(soapEnvelopeBuilder);


        var queryResult = await service.Query(
            startDate,
            endDate,
            emitterRfc,
            receiverRfc,
            requestType,
            downloadType,
            token);


        return queryResult;
    }

    public async Task<QueryResult> Query(QueryParameters parameters, AuthenticateResult token)
    {
        var service = new QueryService(soapEnvelopeBuilder);


        var queryResult = await service.Query(
            parameters.StartDate.ToSatFormat(),
            parameters.EndDate.ToSatFormat(),
            parameters.EmitterRfc,
            parameters.ReceiverRfc,
            parameters.RequestType.ToString(),
            parameters.DownloadType.ToString(),
            token);


        return queryResult;
    }

    public async Task<QueryResult> Query(QueryParameters parameters)
    {
        var token = await GetCurrentToken();

        var service = new QueryService(soapEnvelopeBuilder);


        var queryResult = await service.Query(
            parameters.StartDate.ToSatFormat(),
            parameters.EndDate.ToSatFormat(),
            parameters.EmitterRfc,
            parameters.ReceiverRfc,
            parameters.RequestType.ToString(),
            parameters.DownloadType.ToString(),
            token);


        return queryResult;
    }

    public async Task<VerifyResult> Verify(string? requestUuid, AuthenticateResult token)
    {
        if (string.IsNullOrEmpty(requestUuid))
            throw new ArgumentNullException(nameof(requestUuid));


        var verifyService = new VerifyService(soapEnvelopeBuilder);
        var result = await verifyService.Verify(requestUuid, token);

        return result;
    }

    public async Task<VerifyResult> Verify(string? requestUuid)
    {
        if (string.IsNullOrEmpty(requestUuid))
            throw new ArgumentNullException(nameof(requestUuid));


        var token = await GetCurrentToken();
        var verifyService = new VerifyService(soapEnvelopeBuilder);
        var result = await verifyService.Verify(requestUuid, token);

        return result;
    }
}