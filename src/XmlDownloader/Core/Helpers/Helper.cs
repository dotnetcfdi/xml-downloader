using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Exceptions;
using XmlDownloader.Core.Models;
using XmlDownloader.Core.Models.SatModels.Authenticate;

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
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                SoapAction = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                SoapAction = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                SoapAction =
                    "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
                SoapAction = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar"
            },
            //Retenciones
            new Endpoint
            {
                EndPointName = EndPointName.Authenticate,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                SoapAction = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
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


        public static string CleanXml(string xml)
        {
            //xml = xml.Replace("\r\n", string.Empty);
            //xml = xml.Trim();
            xml = System.Text.RegularExpressions.Regex.Unescape(xml);
            return xml;
        }

    }
}