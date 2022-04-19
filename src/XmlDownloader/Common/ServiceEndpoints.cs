using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Common
{
    /// <summary>
    ///  This class contains the end points to consume the service
    /// Use CfdiEndpoints() for "CFDI regulares"
    /// Use RetEndpoints() for "CFDI de retenciones e información de pagos"
    /// <see cref="CfdiEndpoints"/>
    /// <see cref="RetEndpoints"/>
    /// </summary>
    internal class ServiceEndpoints
    {
        public ServiceEndpoints(string authenticateUrl, string queryUrl, string verifyUrl, string downloadUrl)
        {
            AuthenticateUrl = authenticateUrl;
            QueryUrl = queryUrl;
            VerifyUrl = verifyUrl;
            DownloadUrl = downloadUrl;
        }


        public string? AuthenticateUrl { get; set; }
        public string? QueryUrl { get; set; }
        public string? VerifyUrl { get; set; }
        public string? DownloadUrl { get; set; }

        /// <summary>
        ///  Create an object with known endpoints for "CFDI regulares"
        /// <see cref="WSEndpoints"/>
        /// </summary>
        /// <returns>ServiceEndpoints</returns>
        public static ServiceEndpoints CfdiEndpoints()
        {
            return new ServiceEndpoints(WSEndpoints.CfdiAuthenticate,
                WSEndpoints.CfdiQuery, WSEndpoints.CfdiVerify, WSEndpoints.CfdiDownload);
        }

        /// <summary>
        /// Create an object with known endpoints for "CFDI de retenciones e información de pagos"
        /// <see cref="WSEndpoints"/>
        /// </summary>
        /// <returns></returns>
        public static ServiceEndpoints RetEndpoints()
        {
            return new ServiceEndpoints(WSEndpoints.RetAuthenticate,
                WSEndpoints.RetQuery, WSEndpoints.RetVerify, WSEndpoints.RetDownload);
        }
    }
}