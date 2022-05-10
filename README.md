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

Ejemplo creando el servicio usando una FIEL disponible localmente.

```csharp
C#


```



