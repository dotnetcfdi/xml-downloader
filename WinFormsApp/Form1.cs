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
                 * siéntase libre de no invocarlo, el paquete ya está descargado en la ruta informada en la propiedad ‘Settings.PackagesDirectory’,
                 * usted puede implementar los métodos para la lectura y/o tratamiento de de los mismos 
                 */
            }
        }


        private ICredential GetCredentialFromFiles()
        {
            //Creating a certificate instance
            var cerPath = @"C:\Users\PHILIPS.JESUSMENDOZA\Desktop\cer.cer";
            var cerBytes = File.ReadAllBytes(cerPath);
            var cerBase64 = Convert.ToBase64String(cerBytes);
            var certificate =
                new Certificate(
                    cerBase64); //puedes guardar cerBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperando cerBase64 de la db

            //Creating a private key instance
            var keyPath = @"C:\Users\PHILIPS.JESUSMENDOZA\Desktop\key.key";
            var keyBytes = File.ReadAllBytes(keyPath);
            var keyBase64 = Convert.ToBase64String(keyBytes);
            var privateKey =
                new PrivateKey(keyBase64,
                    "DGE131017"); //puedes guardar keyBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperandolo db


            //Create a credential instance, certificate and privatekey previously created.
            var fiel = new Credential(certificate, privateKey);
            return fiel;
        }

        private ICredential GetCredentialFromDataBase()
        {
            //Creating a certificate instance

            //get cerBase64 from your database (see readme from https://github.com/dotnetcfdi/credentials)

            var cerBase64 =
                "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";
            var certificate =
                new Certificate(
                    cerBase64); //puedes guardar cerBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperando cerBase64 de la db

            //Creating a private key instance

            //get cerBase64 from your database (see readme from https://github.com/dotnetcfdi/credentials)

            var keyBase64 =
                "MIIFDjBABgkqhkiG9w0BBQ0wMzAbBgkqhkiG9w0BBQwwDgQIAgEAAoIBAQACAggAMBQGCCqGSIb3DQMHBAgwggS+AgEAMASCBMh9+jQFIsJGmRB8Ne0DDLPLROR1hBR2Zzcie0kjyWAyvr4Rj3WSTuGyloRP+vtHyKvApoMQd1QiNAxWSlBpJbyYNUd6U2kcfGZsjmmwQGbqCxDgiLrhUO9VxSxC4WBJrgY2uR8MNMBtkihTfAmoQWM/zifW7BwZyYPyf5DQF/IJjadu13F0VeHDNMDdU2jio9KlQOwB8bDN/3FsMqEurX4y/UHP7wTujFHn0SVujX4dGsrQf5dz/tzVaedtQ3SnloT2IkhwTwNKKeeE5ZuI5fvOT7wQ1eIMbJ4O5sC7p7eieyjPbk8rMnKEm/829WbKvN5Arl6H13DzvSxnBkUtXOxREfIEAMzAg11nRzxyXsxBHL55AOrAhQ3WiJdEerlVqoikYobM3NWbOz4GnVFZogYOJsdCdh1ehgyFrxjfN8ZhSRPwJ4REds2Y8Z93wMK3U7xdRzZ1wCNOW8adgTj3zGNTZ14dKZRp02K33giIgjjXG7gUYYKQgOf0WgTSj1agsfrAjHhR7t0Zico2RjSzSpyGeJn4EfvescgztXq35IvrS42+znclWO0aIBSZYNewSdq9lP7pEsvqgpNbIdeDZgipIesu/pG81z2V34LfcT1lznXInF/49qnVynCYNVJXdsXHDLOC4t5CH6DbTVVkekaUlynAkmdqh88y1sL1a6UBk3ejexnLAGLATyl/yFpSi4Q40XZ3egqjYvStpWGU0/RSnGygnTgjXDzuBYXI4R3KWIVhNYUAoFeaE3BfhrTulLtOPIFAxv7REM+gh68ofI0vFh2eLgejTAZ4h0KNPOOcAYdGOXPXSOu6T6IeTIB0vK0g0izdmHhGJNbrlTOl8zjHmIsU/gatsa1Q/D5lJG3kI6O/68MTFcV9GLEJBTjEvJ8FWEUoPskt8mf3mw4PC60ReiW0diO9aLSoXKNP6K1H+tYIOD+oROJp2UE8cOBixBX1QEXxAusTADOXy788QtGTQv8Dp0i/E+baX75pVio9TSMHaZTCrYHb5bOj3Dm7dDkpqccBLDgdsHQv082iuJsTMu5pZjGUKJqGSYjTLdNV/D6gMyG21tGJpEErBnE4YODEc24d6V1xMJcNZwD9ZGwcXNg1w6M5qAzhzE0mT7STYybhKFqAXb9gfvUmtTXyfZGVWdfMoJH9O71ohAotxrNvPfuTpA4u7k3SLGWaIrrlTuL3ukfIH8ge22bHArUSPmPhQLZqfhUBi+YNwzFbV7GoEsono6Vy2QL/v5fIiubMJbCLDf2FNdD+wKNCm21ie9SULENBe4JEybdAUCR4awUetCvR+WIP4tbJFFZBN1SASXZZxZH7Kh7vh6CEAMoEbnn3jkoQd3Gto/aDl56Tp8/hESyG17LYlQWuCAsQ0wsTnlKgKH+FaYvcbcUqgFCGorfTsaf3UuTRrkxMjLyzjeBru1LVIjz9M8nFkRwTyhtxin3R/cUtrEU9iqM1zNO8sT80CRVK6JHem7CpzT7aZ47WOWB9Zb9xFV8Z0r0o4wlfEWvwoEDhCtnUMjSbRCmyWKxquMFMOBtr+iiDXVHa0shSP96XvMBEFpC5629VQb1ajL9BifLRhtZN235mx+Ol2nXUUEMpM1Tsp0GrrHlwTafLncAMDOcdcWo=";
            var privateKey =
                new PrivateKey(keyBase64,
                    "DGE131017"); //puedes guardar keyBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperandolo db


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
                ReceiverRfc = "DGE131017IP1", //Si te interesa CFDI o Metadata recibida, entonces informa este parametro
                RequestType = RequestType.CFDI, // CFDI | Metadata 
                DownloadType = DownloadType.Received //  Emitidos | Recibidos
            };
            return queryParameters;
        }
    }
}