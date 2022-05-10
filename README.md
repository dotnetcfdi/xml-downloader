# dotnetcfdi/XmlDownloader (sat-ws-descarga-masiva)

> Este repo/paquete permite consultar y descargar las facturas que emites y recibes, también se podrá recuperar la información básica de identificación de las facturas llamado metadata.  ([documentación](https://www.sat.gob.mx/consultas/42968/consulta-y-recuperacion-de-comprobantes-(nuevo)), oficial)

Este servicio es bien conocido en el mundo fiscal / contable como “Consulta y recuperación de comprobantes”, fiscalmente es utilizado entre otras cosas para cumplir con la normativa de la contabilidad electrónica, sin embargo, no es la única aplicación, personalmente le he dado los siguientes usos.
 
- Automatizar la cadena de suministros.
- Automatizar tareas de cuentas por pagar.
- Automatizar tareas de cuentas por cobrar.
- Contabilidad electrónica.
- Contabilidad.
- Pólizas contables.


:us: The documentation of this project is in spanish as this is the natural language for intented audience.

:mexico: La documentación del proyecto está en español porque ese es el lenguaje principal de los usuarios.







# Estructura del proyecto

## Organización del código

El código está en `src/` y tiene la siguiente estructura:

- `XmlService` Clase principal de toda la librería, esta clase consume los servicios (`Authenticate`,  `Query`, `Verify` y `Download`)
- `Services\<Service>` Donde los 4 servicios están ubicados.
- `Common` Objetos compartidos.
- `Models` Objetos DTO
- `Packaging` Objetos relacionados con la lectura, serializacion y deserializacón de paquetes descargados del SAT.
- `Builder` Objetos relacionados con la generación de mensajes SOAP Envelope XML usando `Credentials`.
- `SoapClient` Cliente HTTP de comunicación con el Webservice del SAT, definición e implementación.

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

