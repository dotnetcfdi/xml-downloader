using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Models.SatModels.Authenticate.Failure;
using XmlDownloader.Core.Models.SatModels.Authenticate.Success;
using XmlDownloader.Core.Services.Authenticate;
using XmlDownloader.Core.Services.Query;

namespace XmlDownloader.Core.Helpers
{
    public static class Helper
    {
        #region Consts

        private const string SatFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        #endregion


        #region Endpoints

        private static IEnumerable<Endpoint> Endpoints { get; } = new List<Endpoint>()
        {
            new Endpoint
            {
                EndPointName = EndPointName.Authenticate,
                EndPointType = EndPointType.OrdinaryCfdi,
                Uri = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                SoapAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.OrdinaryCfdi,
                Uri = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                SoapAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.OrdinaryCfdi,
                Uri = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                SoapAction =
                    "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.OrdinaryCfdi,
                Uri = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
                SoapAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar"
            },
            //Retenciones
            new Endpoint
            {
                EndPointName = EndPointName.Authenticate,
                EndPointType = EndPointType.RetentionCfdi,
                Uri = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.RetentionCfdi,
                Uri = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.RetentionCfdi,
                Uri = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.RetentionCfdi,
                Uri = "https://retendescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
                SoapAction = null
            }
        };


        public static Endpoint GetEndPoint(EndPointName name, EndPointType type)
        {
            return Endpoints.FirstOrDefault(x => x.EndPointName == name && x.EndPointType == type) ?? new Endpoint();
        }

        public static Endpoint GetAuthenticateEndPoint()
        {
            return GetEndPoint(EndPointName.Authenticate, EndPointType.OrdinaryCfdi);
        }

        public static Endpoint GetQueryEndPoint()
        {
            return GetEndPoint(EndPointName.Query, EndPointType.OrdinaryCfdi);
        }

        public static List<Endpoint> GetAllEndPoints(EndPointType type)
        {
            return Endpoints.Where(x => x.EndPointType == type).ToList();
        }

        #endregion


        #region DateTimeSAT

        public static string ToSatFormat(this DateTime dateTime)
        {
            return dateTime.ToString(SatFormat);
        }

        #endregion


        /// <summary>
        /// Remove horizontal spaces at beginning, carriage return (CR), Line Feed (LF) and xml declaration on its own line.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>cleaned str</returns>
        public static string Clean(this string str)
        {
            #region Comments

            /*
             * Coincidencias Basicas
               .       - Cualquier Caracter, excepto nueva linea
               \d      - Cualquier Digitos (0-9)
               \D      - No es un Digito (0-9)
               \w      - Caracter de Palabra (a-z, A-Z, 0-9, _)
               \W      - No es un Caracter de Palabra.
               \s      - Espacios de cualquier tipo. (espacio, tab, nueva linea)
               \S      - No es un Espacio, Tab o nueva linea.
               
               Limites
               \b      - Limite de Palabra
               \B      - No es un Limite de Palabra
               ^       - Inicio de una cadena de texto
               $       - Final de una cadena de texto
               
               Cuantificadores:
               *       - 0 o Más
               +       - 1 o Más
               ?       - 0 o Uno
               {3}     - Numero Exacto
               {3,4}   - Rango de Numeros (Minimo, Maximo)
               
               Conjuntos de Caracteres
               []      - Caracteres dentro de los brackets
               [^ ]    - Caracteres que NO ESTAN dentro de los brackets
               
               Grupos
               ( )     - Grupo
               |       - Uno u otro
             */

            #endregion

            // A: remove horizontal spaces at beginning
            str = Regex.Replace(str, @"^\s*", string.Empty, RegexOptions.Multiline).TrimStart();


            // B: remove horizontal spaces + optional CR + LF
            str = Regex.Replace(str, @"\s*\r?\n", string.Empty, RegexOptions.Multiline).TrimEnd();

            // C: xml declaration on its own line
            str = str.Replace(@"?><", @$"?>{Environment.NewLine}<");

            return string.IsNullOrEmpty(str) ? string.Empty : str;
        }


        public static AuthenticateResult GetAuthenticateResult(string? rawResponse)
        {
            var token = new AuthenticateResult();

            // AuthenticateResult
            if (string.IsNullOrEmpty(rawResponse))
                return token;

            var xml = new XmlDocument();
            xml.LoadXml(rawResponse);


            var created = xml?.DocumentElement?.GetElementsByTagName("u:Created")[0]?.InnerText;

            var expires = xml?.DocumentElement?.GetElementsByTagName("u:Expires")[0]?.InnerText;

            var autenticaResult = xml?.DocumentElement?.GetElementsByTagName("AutenticaResult")[0]?.InnerText;


            if (created is null | expires is null | autenticaResult is null)
            {
                var faultcode = xml?.DocumentElement?.GetElementsByTagName("faultcode")[0]?.InnerText;
                var faultstring = xml?.DocumentElement?.GetElementsByTagName("faultstring")[0]?.InnerText;

                token.ErrorMessage = $"{faultcode}: {faultstring}";
                return token;
            }


            token.ValidFrom = Convert.ToDateTime(created);
            token.ValidTo = Convert.ToDateTime(expires);
            token.Value = $"WRAP access_token=\"{HttpUtility.UrlDecode(autenticaResult)}\"";
            token.IsSuccess = true;


            return token;
        }

        public static QueryResult GetQueryResult(string? rawResponse)
        {
            var result = new QueryResult();

            if (string.IsNullOrEmpty(rawResponse)) return result;


            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(rawResponse);


            var statusCode = xmlDoc.GetElementsByTagName("SolicitaDescargaResult")[0]
                ?.Attributes?["CodEstatus"]
                ?.Value;

            var message =
                xmlDoc.GetElementsByTagName("SolicitaDescargaResult")[0]?.Attributes?["Mensaje"]?.Value;

            var requestUuid = xmlDoc.GetElementsByTagName("SolicitaDescargaResult")[0]
                ?.Attributes?["IdSolicitud"]
                ?.Value;


            if (statusCode is null || message is null || requestUuid is null) return result;

            result.RequestId = requestUuid;
            result.StatusCode = statusCode;
            result.Message = message;
            result.IsSuccess = string.Equals(statusCode, "5000");

            return result;
        }
    }
}