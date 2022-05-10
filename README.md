# dotnetcfdi/XmlDownloader (sat-ws-descarga-masiva)

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

## Ejemplos de uso

Todos los objetos de entrada y salida se pueden exportar como JSON, adicionalmente  las clases `AuthenticateResult` `QueryResult` `VerifyResult` y  `DownloadResult` implementan la la interface  `IHasInternalRequestResponse` que exponen la propiedad `RawRequest` y `RawResponse` que permite recuperar el mensaje `SOAP Envelope` de cada uno de los servicios, también implementan `IHasSuccessResponse` que expone una propiedad `bool` que indica si la operacion fue exitosa o no, estas características fueron pensadas para facilitar el análisis y depuración en producción o en desarrollo. 


### Creación el servicio

Ejemplo creando el servicio usando una FIEL disponible localmente.

```csharp
C#
//Creating a certificate instance
var cerPath = @"C:\Users\JESUSMENDOZA\Desktop\cer.cer";
var cerBytes = File.ReadAllBytes(cerPath);
var cerBase64 = Convert.ToBase64String(cerBytes); 
var certificate = new Certificate(cerBase64); //puedes guardar cerBase64 en la db, entonces omite las lineas anteriores y crea el objeto recuperando cerBase64 de la db

//show certificate basic information
MessageBox.Show($@"PlainBase64 {certificate.PlainBase64}");
MessageBox.Show($@"Rfc {certificate.Rfc}");
MessageBox.Show($@"Razón social {certificate.Organization}");
MessageBox.Show($@"SerialNumber {certificate.SerialNumber}");
MessageBox.Show($@"CertificateNumber {certificate.CertificateNumber}");
MessageBox.Show($@"ValidFrom {certificate.ValidFrom}");
MessageBox.Show($@"ValidTo {certificate.ValidTo}");
MessageBox.Show($@"IsFiel { certificate.IsFiel()}");
MessageBox.Show($@"IsValid { certificate.IsValid()}"); // ValidTo > Today

//Converts X.509 DER base64 or X.509 DER to X.509 PEM
var pemCertificate = certificate.GetPemRepresentation();
File.WriteAllText("MyPemCertificate.pem", pemCertificate);

```



