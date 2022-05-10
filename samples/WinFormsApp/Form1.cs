using System.Diagnostics.CodeAnalysis;
using Credencials.Core;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Services;
using XmlDownloader.Core.Services.Common;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private ICredential credential;
        private XmlService service;

        public Form1()
        {
            InitializeComponent();

            //Descomenta si quieres construir la credencil desde los archivos
            //credential = GetCredentialFromFiles();

            //Descomenta si quieres construir la credencil desde los string base64 de los archivos
            //Normalmente este proceso es utilizado porque solo lees los bytes de los archivos, 
            //Despues codificas los Bytes en base 64 y entonces los puedes almacenar y recuperar en cualquier db
            //esto es muy util en aplicaciones web, y en desktop cuando no quieres enfrentar problemas con rutas de los .cer/.key
            credential = GetCredentialFromDataBase(); // GetCredentialFromFiles();


            ConfigureGlobalSettings();

            service = new XmlService(credential);
        }

        private static void ConfigureGlobalSettings()
        {
            Settings.EnableRedundantWriting = true;

            Settings.LogsDirectory = @"C:\MylogsFolder"; //your folder for logs
            Settings.PackagesDirectory = @"C:\MyPackagesFolder"; //your folder to save .zip Packages
            Settings.WorkDirectory = @"C:\MyTempFolder"; //your folder to uncompress and read Packages.


            //Save package a Package copy into PackagesDirectory, then uncompress into WorkDirectory
            //Si esta propiedad NO está en true, entonces solo podrá recuperar su paquete 2 veces (el sat solo entrega el mismo paquete 2 veces)
            //Si por alguna circunstancia, usted no persiste ese paquete manualmente, el paquete lo hará por usted si y solo si, esta propiedad está  establecida en true. (depende de PackagesDirectory)
            Settings.EnableRedundantWriting = true;


            // Settings.PackageExtension is by default .zip
        }


        private async void CfdiButton_Click(object sender, EventArgs e)
        {
            //De acuerdo con la documentación del SAT,  el token de autorización se construye por 5 minutos y este token se utiliza en los cuatro web services que integran la descarga masiva,
            //el token se debe verificar cada 5 minutos y en caso de que esté expirado, entonces solicitar uno nuevo, todas esas tareas las gestiona automáticamente la librería,
            //por lo cual el uso del token para el desarrollador es exclusivamente informativo. 

            //No es necesario almacenar manualmente el token todas las tareas de autenticacion y autorización
            //son  gestionadas internamente por el paquete, solo haga la llamada a AuthenticateAsync()
            var authResult = await service.AuthenticateAsync();


            if (!authResult.IsSuccess) return; //Indica si la operacion fue exitosa, si no romper el flujo.


            //Este objeto es la parametrización de del segundo web service, en este objeto se pueden informar las configuraciones deseadas,
            //por ejemplo, si quieres descargar CFDI emitidos o recibidos, si quieres CFDI o Metadata, así como el periodo que comprende la información deseada.
            //Este objeto es enviado como parametro al web service Query (llamado por el SAT solocitud)
            var queryParameters = GetQueryParameters();
            var queryResult = await service.Query(queryParameters);
            if (!queryResult.IsSuccess) return; //Indica si la operacion fue exitosa, si no romper el flujo.


            //Esperar un tiempo para preguntar por el estado de nuestra solicitud, si omites la espera,
            //los más probable es que el SAT de indique que aún no está lista su solicitud,
            //No hay un tiempo específico, mi recomendación es al menos 1 minuto (60,000 ms), pero puedes colocar mucho más,
            //no te preocupes por la vigencia del token, el paquete renovará automáticamente en segundo plano, si este se expira.
            //Se recomienda consumir estos web services en segundo plano porque la espera del hilo principal genera "mala experiencia de usuario".
            //Exiten varias librerias que atienden esta necesidad por ej. (https://www.quartz-scheduler.net/ | https://www.hangfire.io/ | https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=net-6.0) 
            Thread.Sleep(60_000);


            //Después de generar la llamada al web servicie query (solicitud por el SAT), el sat NO devuelve los cfdis o Metadata de esa solicitud,
            //solo nos confirma o declina que ya recibió la solicitud, pero debemos esperar un tiempo antes de consultar el tercer web service (Verify).
            //Verify permite conocer el estado de nuestra solicitud, para cuando esté lista, entonces consumir el ultimo web service (download)
            var verifyResult = await service.Verify(queryResult.RequestUuid);
            if (!verifyResult.IsSuccess) return; //Indica si la operacion fue exitosa, si no romper el flujo.


            foreach (var packageId in verifyResult.PackagesIds)
            {
                var downloadResult = await service.Download(packageId);
                if (!downloadResult.IsSuccess) return; //Indica si la operacion fue exitosa, si no romper el flujo.


                //Tenga cuidado con el uso de este método GetCfdisAsync(), es te método es de gran utilidad,
                //porque te va entregar una lista de objetos Comprobante que representa cada
                //XML descargado.  con ello tu puedes acceder a todas las propiedades del cfdi,,
                //desde el uuid, emisor, receptor conceptos, impuestos, timbre, complementos, etc.
                //En lugar de una simple ruta donde se escribió el paquete .ZIP de XMls,
                //sin embargo esto tiene un costo en memoria RAM, por lo cual le sugiero encarecidamente
                //que los periodos de tiempo de las consultas no sean exagerados, porque descargará todos los xml y después des de-serializa y carga en memoria. 

                //En términos generales, entre mas corto sea el periodo de la consulta, menos
                //memoria RAM consume este método y viceversa. 
                var cfdiList = await service.GetCfdisAsync(downloadResult);


                //En el caso de que el objeto queryParameters esté configurado para metadata,
                //consumir invocar GetMetadataAsync(downloadResult), en lugar de GetCfdisAsync(downloadResult)
                // var metadata = await service.GetMetadataAsync(downloadResult);


                //NOTA IMPORTANTE//
                /*
                 * Si usted no está dispuesto o la naturaleza de su aplicación no le permite asumir el
                 * costo de la deserialización y carga a memoria de del método GetCfdisAsync(downloadResult),
                 * siéntase libre de no invocarlo, el paquete de cfdi ya está descargado y almacenado en la ruta establecida en ‘Settings.PackagesDirectory’,
                 * usted puede implementar los métodos para la lectura y/o tratamiento de de los mismos,
                 * GetCfdisAsync(), GetMetadataAsync() son helpers, pero la descarga ya está en su equipo.
                 */
            }
        }


        private ICredential GetCredentialFromFiles()
        {
            //Creating a certificate instance
            var cerPath = @"C:\Users\JESUSMENDOZA\Desktop\cer.cer";
            var cerBytes = File.ReadAllBytes(cerPath);
            var cerBase64 = Convert.ToBase64String(cerBytes);
            var certificate =
                new Certificate(
                    cerBase64); //puedes guardar cerBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperando cerBase64 de la db

            //Creating a private key instance
            var keyPath = @"C:\Users\JESUSMENDOZA\Desktop\key.key";
            var keyBytes = File.ReadAllBytes(keyPath);
            var keyBase64 = Convert.ToBase64String(keyBytes);
            var privateKey =
                new PrivateKey(keyBase64,
                    "YourPassPhrase"); //puedes guardar keyBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperandolo db


            //Create a credential instance, certificate and privatekey previously created.
            var fiel = new Credential(certificate, privateKey);
            return fiel;
        }

        private ICredential GetCredentialFromDataBase()
        {
            //Creating a certificate instance

            //get cerBase64 from your database (see readme from https://github.com/dotnetcfdi/credentials)

            var cerBase64 =
                "YourCerBase64String";
            var certificate =
                new Certificate(
                    cerBase64); //puedes guardar cerBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperando cerBase64 de la db

            //Creating a private key instance

            //get cerBase64 from your database (see readme from https://github.com/dotnetcfdi/credentials)

            var keyBase64 =
                "YourCerBase64String";
            var privateKey =
                new PrivateKey(keyBase64,
                    "YourPassPhrase"); //puedes guardar keyBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperandolo db


            //Create a credential instance, certificate and privatekey previously created.
            var fiel = new Credential(certificate, privateKey);
            return fiel;
        }

        private QueryParameters GetQueryParameters()
        {
            var queryParameters = new QueryParameters
            {
                StartDate = new DateTime(2022, 1, 14, 0, 0, 0),
                EndDate = new DateTime(2022, 1, 17, 23, 59, 59),
                EmitterRfc = null, //Si te interesa CFDI o Metadata emitida, entonces informa este parametro
                ReceiverRfc = "YourRfc", //Si te interesa CFDI o Metadata recibida, entonces informa este parametro
                RequestType = RequestType.CFDI, // CFDI | Metadata 
                DownloadType = DownloadType.Received //  Emitidos | Recibidos
            };
            return queryParameters;
        }
    }
}