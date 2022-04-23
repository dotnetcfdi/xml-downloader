using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Exceptions;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Models.SatModels.Authenticate;
using XmlDownloader.Core.Models.SatModels.Authenticate.Failure;
using XmlDownloader.Core.Models.SatModels.Authenticate.Success;

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


        #region LinqToXml

        #endregion

        public static Token GetTokenByRawResponse(string? rawResponse)
        {
            if (string.IsNullOrEmpty(rawResponse)) return new Token();




            var xml = new XmlDocument();
            xml.LoadXml(rawResponse);

            IEnumerable<XElement> childList =
                from el in xml.OuterXml.Elements()
                select el;




            File.WriteAllText("fail.xml", rawResponse);


            rawResponse = @"<s:Envelope><s:Body><s:Fault><faultcode xmlns:a=\""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\"">a:InvalidSecurity</faultcode><faultstring xml:lang=\""en-US\"">An error occurred when verifying security for the message.</faultstring></s:Fault></s:Body></s:Envelope>";

            var failureEnvelope = Deserialize<ErrorEnvelope>(rawResponse);


            var authenticateEnvelope = Deserialize<AuthenticateEnvelope>(rawResponse);

            var token = new Token
            {
                ValidFrom = authenticateEnvelope.Header.Security.Timestamp.Created,
                ValidTo = authenticateEnvelope.Header.Security.Timestamp.Expires,
                Value = authenticateEnvelope.Body.AutenticaResponse.AutenticaResult
            };

            return new Token();
        }

        public static T Deserialize<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));
            var result = (T) serializer.Deserialize(new StringReader(xml));

            return (T) result;
        }

        /// <summary>
        /// Remove horizontal spaces at beginning, carriage return (CR), Line Feed (LF) and xml declaration on its own line.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>cleaned str</returns>
        public static string CleanXml(this string str)
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
    }
}