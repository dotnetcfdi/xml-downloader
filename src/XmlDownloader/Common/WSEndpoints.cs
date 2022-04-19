using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDownloader.Common
{
    internal static class WSEndpoints
    {
        public const string CfdiAuthenticate = @"https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        public const string CfdiQuery = @"https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        public const string CfdiVerify = @"https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        public const string CfdiDownload = @"https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";

        public const string RetAuthenticate = @"https://retendescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc";
        public const string RetQuery = @"https://retendescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc";
        public const string RetVerify = @"https://retendescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc";
        public const string RetDownload = @"https://retendescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc";
    }
}