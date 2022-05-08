using XmlDownloader.Core.Services.Common;

namespace XmlDownloader.Core.Services.Authenticate
{
    /// <summary>
    /// Define token 
    /// </summary>
    public class AuthenticateResult : IHasSuccessResponse
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
    }
}