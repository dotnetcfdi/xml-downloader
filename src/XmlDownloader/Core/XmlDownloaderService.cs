using Credencials.Core;
using XmlDownloader.Core.Builder;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Services.Authenticate;

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
}