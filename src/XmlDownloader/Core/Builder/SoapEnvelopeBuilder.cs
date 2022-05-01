using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credencials.Common;
using Credencials.Core;
using XmlDownloader.Core.Common;
using XmlDownloader.Core.Helpers;
using XmlDownloader.Core.Models;

namespace XmlDownloader.Core.Builder;

public class SoapEnvelopeBuilder
{
    private readonly ICredential credential;

    public SoapEnvelopeBuilder(ICredential credential)
    {
        this.credential = credential;
    }

    public string BuildAuthenticate(DateTimePeriod? tokenPeriod = null, string securityTokenId = "")
    {
        tokenPeriod ??= DateTimePeriod.CreateTokenPeriod();

        securityTokenId = string.IsNullOrEmpty(securityTokenId) ? CreateXmlSecurityTokenId() : securityTokenId;
        var certB64 = credential.Certificate.RawDataBytes.ToBase64String();


        var toDigest =
            @$"<u:Timestamp xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" u:Id=""_0"">
                <u:Created>{tokenPeriod.StartDateSat}</u:Created>
                <u:Expires>{tokenPeriod.EndDateSat}</u:Expires>
            </u:Timestamp>";


        var digest = credential.CreateHash(toDigest.Clean());


        var canonicalSignedInfo = CreateCanonicalSignedInfoXml(digest);

        var signature = credential.SignData(canonicalSignedInfo.Clean()).ToBase64String();


        #region Comments

        //var soapEnvelope =
        //    @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
        //      <s:Header>
        //      <o:Security s:mustUnderstand=""1"" xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
        //       <u:Timestamp u:Id=""_0"">
        //        <u:Created>{tokenPeriod.Created}</u:Created>
        //        <u:Expires>{tokenPeriod.Expires}</u:Expires>
        //       </u:Timestamp>
        //                <o:BinarySecurityToken u:Id=""{securityTokenId}"" ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">
        //                {certB64}
        //                </o:BinarySecurityToken>
        //                <Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
        //                    <SignedInfo>
        //         <CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
        //         <SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>
        //         <Reference URI=""#_0"">
        //          <Transforms>
        //           <Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
        //          </Transforms>
        //          <DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""/>
        //          <DigestValue>{digest}</DigestValue>
        //         </Reference>
        //         </SignedInfo>
        //                    <SignatureValue>{signature}</SignatureValue>
        //        <KeyInfo>
        //         <o:SecurityTokenReference>
        //          <o:Reference ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" URI=""#{securityTokenId}""/>
        //         </o:SecurityTokenReference>
        //        </KeyInfo>
        //                </Signature>
        //      </o:Security>
        //      </s:Header>
        //        <s:Body>
        //      <Autentica xmlns=""http://DescargaMasivaTerceros.gob.mx""/>
        //     </s:Body>
        //    </s:Envelope>";

        #endregion


        var soapEnvelope =
            @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
	             <s:Header>
		            <o:Security s:mustUnderstand=""1"" xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
			            <u:Timestamp u:Id=""_0"">
				            <u:Created>{tokenPeriod.StartDateSat}</u:Created>
				            <u:Expires>{tokenPeriod.EndDateSat}</u:Expires>
			            </u:Timestamp>
                        <o:BinarySecurityToken u:Id=""{securityTokenId}"" ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">
                        {certB64}
                        </o:BinarySecurityToken>
                        <Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
                           {canonicalSignedInfo}
                            <SignatureValue>{signature}</SignatureValue>
				            <KeyInfo>
					            <o:SecurityTokenReference>
						            <o:Reference ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" URI=""#{securityTokenId}""/>
					            </o:SecurityTokenReference>
				            </KeyInfo>
                        </Signature>
		            </o:Security>
	             </s:Header>
                <s:Body>
		            <Autentica xmlns=""http://DescargaMasivaTerceros.gob.mx""/>
	            </s:Body>
            </s:Envelope>";

        return soapEnvelope.Clean();
    }


    public string BuildQuery(string startDate, string endDate, string requestType, string downloadType,
        string? emitterRfc, string? receiverRfc)
    {
        var signerRfc = credential.Certificate.Rfc;


        var toDigestXml = downloadType.Equals(DownloadType.Emitted.ToString()) ?
            @$"<des:SolicitaDescarga xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"">
	            <des:solicitud RfcSolicitante=""{signerRfc}"" FechaInicial=""{startDate}"" FechaFinal=""{endDate}"" TipoSolicitud=""{requestType} RfcEmisor=""{emitterRfc}"">
	            </des:solicitud>
            </des:SolicitaDescarga>" :
            @$"<des:SolicitaDescarga xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"">
	            <des:solicitud RfcSolicitante=""{signerRfc}"" FechaInicial=""{startDate}"" FechaFinal=""{endDate}"" TipoSolicitud=""{requestType}"">
		            <des:RfcReceptores>
			            <des:RfcReceptor>{receiverRfc}</des:RfcReceptor>
		            </des:RfcReceptores>
	            </des:solicitud>
            </des:SolicitaDescarga>";


        var digestValue = credential.CreateHash(toDigestXml.Clean());

        var canonicalSignedInfo = CreateCanonicalSignedInfoXml(digestValue);

        var signatureValue = credential.SignData(canonicalSignedInfo.Clean()).ToBase64String();

        var signatureXml = CreateSignatureXml(digestValue, signatureValue);


        var rawRequest = downloadType.Equals(DownloadType.Emitted.ToString()) ?
            @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"" xmlns:xd=""http://www.w3.org/2000/09/xmldsig#"">
	                <s:Header/>
	                <s:Body>
		                <des:SolicitaDescarga>
			                <des:solicitud RfcSolicitante=""{signerRfc}"" FechaInicial=""{startDate}"" FechaFinal=""{endDate}"" TipoSolicitud=""{requestType}"" RfcEmisor=""{emitterRfc}"">
				                {signatureXml}
			                </des:solicitud>
		                </des:SolicitaDescarga>
	                </s:Body>
                </s:Envelope>" :
            @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"" xmlns:xd=""http://www.w3.org/2000/09/xmldsig#"">
	                <s:Header/>
	                <s:Body>
		                <des:SolicitaDescarga>
			                <des:solicitud RfcSolicitante=""{signerRfc}"" FechaInicial=""{startDate}"" FechaFinal=""{endDate}"" TipoSolicitud=""{requestType}"" >
				                <des:RfcReceptores>
					                <des:RfcReceptor>{receiverRfc}</des:RfcReceptor>
				                </des:RfcReceptores>
				                {signatureXml}
			                </des:solicitud>
		                </des:SolicitaDescarga>
	                </s:Body>
                </s:Envelope>";


        return rawRequest.Clean();
    }

    #region Builder Helpers

    private static string CreateXmlSecurityTokenId()
    {
        return $"uuid-{Guid.NewGuid().ToString()}-1";
    }

    private static string CreateCanonicalSignedInfoXml(string digest)
    {
        var xml =
            @$"<SignedInfo xmlns=""http://www.w3.org/2000/09/xmldsig#"">
	                <CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""></CanonicalizationMethod>                                             
	                <SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""></SignatureMethod>
	                <Reference URI=""#_0"">
		                <Transforms>
			                <Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""></Transform>
		                </Transforms>
		                <DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""></DigestMethod>
		                <DigestValue>{digest}</DigestValue>
	                </Reference>
              </SignedInfo>";

        return xml;
    }


    private string CreateSignatureXml(string digestValue, string signatureValue)
    {
        var xml =
            @$"<Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
					<SignedInfo>
						<CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
						<SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>
                        <Reference URI=""#_0"">
							<Transforms>
								<Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
							</Transforms>
							<DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""/>
							<DigestValue>{digestValue}</DigestValue>
						</Reference>
					</SignedInfo>
					<SignatureValue>{signatureValue}</SignatureValue>
					<KeyInfo>
						<X509Data>
							<X509IssuerSerial>
								<X509IssuerName>{credential.Certificate.Issuer}</X509IssuerName>
								<X509SerialNumber>{credential.Certificate.SerialNumber}</X509SerialNumber>
							</X509IssuerSerial>
							<X509Certificate>{credential.Certificate.RawDataBytes.ToBase64String()}</X509Certificate>
						</X509Data>
					</KeyInfo>
			</Signature>";


        return xml.Clean();
    }

    #endregion
}