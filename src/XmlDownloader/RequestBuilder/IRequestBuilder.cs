namespace XmlDownloader.RequestBuilder
{
    /// <summary>
    /// The implementors must create the request signed ready to send to the SAT Web Service Descarga Masiva
    /// The information about owner like RFC, certificate, private key, etc.are outside the scope of this interface
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        ///  Creates an authorization signed xml message
        /// </summary>
        /// <param name="created">must use SAT format 'Y-m-d\TH:i:s.000T</param>
        /// <param name="expires">must use SAT format 'Y-m-d\TH:i:s.000T</param>
        /// <param name="securityTokenId">if empty, the authentication method will create one by its own</param>
        /// <returns>Authorization SOAP envelope</returns>
        public string Authorization(string created, string expires, string securityTokenId = "");
    }
}