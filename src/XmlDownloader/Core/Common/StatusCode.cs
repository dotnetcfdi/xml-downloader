using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Core.Common
{
    /// <summary>
    /// Defines "CodEstatus" and "Mensaje"
    /// </summary>
    public class StatusCode
    {
        //Contains the value of "CodEstatus"
        public int Code { get; set; }

        //Contains the value of "Mensaje"
        public string? Message { get; set; }

        /// <summary>
        /// The only success code is "5000: Solicitud recibida con éxito"
        /// </summary>
        /// <returns>Return true when "CodEstatus" is success.</returns>
        public bool isAccepted()
        {
            return Code == 5000;
        }
    }
}