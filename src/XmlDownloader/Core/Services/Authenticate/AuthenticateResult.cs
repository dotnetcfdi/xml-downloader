using XmlDownloader.Core.Services.Common;
using XmlDownloader.Core.SoapClient;

namespace XmlDownloader.Core.Services.Authenticate
{
    /// <summary>
    /// Define token 
    /// </summary>
    public class AuthenticateResult : IHasSuccessResponse, IHasInternalRequestResponse
    {
       
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }

        public bool IsValid()
        {
            return !IsEmptyValue() && !IsExpired();
        }

        public bool IsEmptyValue()
        {
            return string.IsNullOrEmpty(Value);
        }

        public bool IsExpired()
        {
            return ValidTo <= DateTime.Now;
        }


        public InternalRequest? InternalRequest { get; set; }
        public InternalResponse? InternalResponse { get; set; }
    }
}