using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDownloader.Models;

namespace XmlDownloader.Common
{
    internal static class EndpointHelper
    {
        private static List<Endpoint> Endpoints { get; set; } = new List<Endpoint>()
        {
            new Endpoint
            {
                EndPointName = EndPointName.Authenticate,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                Action = "http://DescargaMasivaTerceros.gob.mx/IAutenticacion/Autentica"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                Action = "http://DescargaMasivaTerceros.sat.gob.mx/ISolicitaDescargaService/SolicitaDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                Action =
                    "http://DescargaMasivaTerceros.sat.gob.mx/IVerificaSolicitudDescargaService/VerificaSolicitudDescarga"
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.OrdinaryCfdi,
                Url = "https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
                Action = "http://DescargaMasivaTerceros.sat.gob.mx/IDescargaMasivaTercerosService/Descargar"
            },
            //Retenciones
            new Endpoint
            {
                EndPointName = EndPointName.Authenticate,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc",
                Action = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Query,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc",
                Action = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Verify,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc",
                Action = null
            },
            new Endpoint
            {
                EndPointName = EndPointName.Download,
                EndPointType = EndPointType.RetentionCfdi,
                Url = "https://retendescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc",
                Action = null
            }
        };


        public static Endpoint? GetEndPoint(EndPointName name, EndPointType type)
        {
            return Endpoints.FirstOrDefault(x => x.EndPointName == name && x.EndPointType == type);
        }


        public static List<Endpoint> GetAllEndPoints(EndPointType type)
        {
            return Endpoints.Where(x => x.EndPointType == type).ToList();
        }
    }
}