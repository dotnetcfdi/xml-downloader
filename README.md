# dotnetcfdi/xml-downloader (sat-ws-descarga-masiva)

---
:us: The documentation of this project is in spanish as this is the natural language for intended audience.

:mexico: La documentación del proyecto está en español porque ese es el lenguaje principal de los usuarios.

---

Este repo/paquete permite consultar y descargar las facturas que emites y recibes, también se podrá recuperar la información básica de identificación de las facturas llamado metadata.  ([documentación](https://www.sat.gob.mx/consultas/42968/consulta-y-recuperacion-de-comprobantes-(nuevo)), oficial).<br>
Este servicio es bien conocido en el mundo fiscal / contable como “Consulta y recuperación de comprobantes”, fiscalmente es utilizado entre otras cosas para cumplir con la normativa de la contabilidad electrónica, sin embargo, no es la única aplicación, personalmente le he dado los siguientes usos.
 
- Automatizar la cadena de suministros.
- Automatizar tareas de cuentas por pagar.
- Automatizar tareas de cuentas por cobrar.
- Contabilidad electrónica.
- Contabilidad.
- Pólizas contables.


# Estructura del proyecto

### Organización del código

El código está en `src/` y tiene la siguiente estructura:

- `XmlService` Clase principal de toda la librería, esta clase consume los servicios (`Authenticate`,  `Query`, `Verify` y `Download`)
- `Services\<Service>` Donde los 4 servicios están ubicados.
- `Common` Objetos compartidos.
- `Models` Objetos DTO
- `Packaging` Objetos relacionados con la lectura, serializacion y deserializacón de paquetes descargados del SAT.
- `Builder` Objetos relacionados con la generación de mensajes SOAP Envelope XML usando `Credentials`.
- `SoapClient` Objetos relacionados con el cliente HTTP de comunicación con el Webservice del SAT, definición e implementación. 

### `Services\<Service>`

Hay cuatro servicios fundamentales, los objetos particulares de estos servicios están almacenados en cada directorio

- `Services\Authenticate`
- `Services\Query`
- `Services\Verify`
- `Services\Download` 
Cada servicio puede contener algunos objetos con propósito especial.

- `Result` Resultado de la operación de consumir el servicio.
- `Parameters` Parámetros para realizar la operación.


## Instalación

Usa [nuget](https://www.nuget.org/)

```shell

Install-Package DotnetCfdi.XmlDownloader -Version 1.0.0

```

:warning: Esta libreria depende de [dotnetcfdi/credentials](https://github.com/dotnetcfdi/credentials/) se recomienda leer la documentación y volver a este punto.

 

## Acerca del Servicio Web de Descarga Masiva de CFDI y Retenciones

El servicio se compone de 4 partes:

1. Autenticación: Esto se hace con tu FIEL y la libería oculta la lógica de obtener y usar el Token.
2. Solicitud: Presentar una solicitud incluyendo la fecha de inicio, fecha de fin, tipo de solicitud
   emitidas/recibidas y tipo de información solicitada (cfdi o metadata).
3. Verificación: pregunta al SAT si ya tiene disponible la solicitud.
4. Descargar los paquetes emitidos por la solicitud.

El siguiente diagrama muestra el macro flujo del uso del los web services del SAT.
![Diagram](https://user-images.githubusercontent.com/28969854/167732245-23c30b94-3feb-4d89-bee6-2b0f591203cf.svg)


### Información oficial

- Liga oficial del SAT
  <https://www.sat.gob.mx/consultas/42968/consulta-y-recuperacion-de-comprobantes-(nuevo)>
- Solicitud de descargas para CFDI y retenciones:
  <https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1579314716402&ssbinary=true>
- Verificación de descargas de solicitudes exitosas:
  <https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1579314716409&ssbinary=true>
- Descarga de solicitudes exitosas:
  <https://www.sat.gob.mx/cs/Satellite?blobcol=urldata&blobkey=id&blobtable=MungoBlobs&blobwhere=1579314716395&ssbinary=true>

Notas importantes del web service:

- Podrás recuperar hasta 200 mil registros por petición y hasta 1,000,000 en metadata.
- No existe limitante en cuanto al número de solicitudes siempre que no se descargue en más de dos ocasiones un XML.

### Notas de uso

- No se aplica la restricción de la documentación oficial: *que no se descargue en más de dos ocasiones un XML*.

Se ha encontrado que la regla relacionada con las descargas de tipo CFDI no se aplica en la forma como está redactada.
Sin embargo, se ha encontrado que la regla que sí aplica es: *no solicitar en más de 2 ocasiones el mismo periodo*.
Cuando esto ocurre, el proceso de solicitud devuelve el mensaje *"5002: Se han agotado las solicitudes de por vida"*.

Recuerda que, si se cambia la fecha inicial o final en al menos un segundo ya se trata de otro periodo,
por lo que si te encuentras en este problema podrías solucionarlo de esta forma.

En consultas del tipo Metadata no se aplica la limitante mencionada anteriormente, por ello es recomendable
hacer las pruebas de implementación con este tipo de consulta.

- Tiempo de respuesta entre la presentación de la consulta y su verificación exitosa.

No se ha podido encontrar una constante para suponer el tiempo que puede tardar una consulta en regresar un estado
de verificación exitosa y que los paquetes estén listos para descargarse.

En nuestra experiencia, entre más grande el periodo y más consultas se presenten más lenta es la respuesta,
y puede ser desde minutos a horas. Por lo general es raro que excedan 24 horas.
Sin embargo, varios usuarios han experimentado casos raros (posiblemente por problemas en el SAT) en donde las
solicitudes han llegado a tardar hasta 72 horas para ser completadas.

## Ejemplos de uso

Todos los objetos de entrada y salida se pueden exportar como JSON, adicionalmente  las clases `AuthenticateResult` `QueryResult` `VerifyResult` y  `DownloadResult` implementan la la interface  `IHasInternalRequestResponse` que exponen la propiedad `RawRequest` y `RawResponse` que permite recuperar el mensaje `SOAP Envelope` de cada uno de los servicios, también implementan `IHasSuccessResponse` que expone una propiedad `bool` que indica si la operacion fue exitosa o no, estas características fueron pensadas para facilitar el análisis y depuración en producción o en desarrollo.
### Creación del servicio

Ejemplo (vea los detalles en el proyecto demo de la carpeta `samples/WinFormApp`, esto funciona tanto en web, console y desktop. (.NET 6 por ahora)


```csharp
C#

  private async void CfdiButton_Click(object sender, EventArgs e)
        {


            #region Generar objeto credential 

            //Descomenta si quieres construir la credencil desde los archivos
            //credential = GetCredentialFromFiles();

            //Descomenta si quieres construir la credencil desde los string base64 de los archivos
            //Normalmente este proceso es utilizado porque solo lees los bytes de los archivos, 
            //Despues codificas los Bytes en base 64 y entonces los puedes almacenar y recuperar en cualquier db
            //esto es muy util en aplicaciones web, y en desktop cuando no quieres enfrentar problemas con rutas de los .cer/.key
            credential = GetCredentialFromDataBase(); // GetCredentialFromFiles();


            #endregion

            ConfigureGlobalSettings();

            service = new XmlService(credential);


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

```
## Compatibilidad

Esta librería se mantendrá compatible con al menos la versión con
[soporte LTS de dotnet](https://dotnet.microsoft.com/en-us/download/dotnet) más reciente.

También utilizamos [Versionado Semántico 2.0.0](docs/SEMVER.md) por lo que puedes usar esta librería
sin temor a romper tu aplicación.

Actualmente compatible con `.NET 6`, winforms, console y web. 

## Contribuciones

Las contribuciones con bienvenidas. Por favor lee [CONTRIBUTING][] para más detalles
y recuerda revisar el archivo de tareas pendientes [TODO][] y el archivo [CHANGELOG][].


## Roadmap Features 
- [x] Descargar cfdi emitidos y recibidos
- [x] Descargar metadata de cfdi emitidos y recibidos
- [ ] Documentación.

## Copyright and License

The `dotnet/xml-downloader` library is copyright © [dotnetcfdi](https://www.dotnetcfdi.com/)
and licensed for use under the MIT License (MIT). Please see [LICENSE][] for more information.


