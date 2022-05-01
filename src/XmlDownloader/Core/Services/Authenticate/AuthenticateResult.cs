using XmlDownloader.Core.Common;

namespace XmlDownloader.Core.Services.Authenticate
{
    /// <summary>
    /// Define token 
    /// </summary>
    public class AuthenticateResult: IHasSuccessResponse
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}