using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credencials.Common;
using Credencials.Core;
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


        var digest = credential.CreateHash(toDigest.CleanXml());


        var canonicalSignedInfo = CreateCanonicalSignedInfoXml(digest);

        var signature = credential.SignData(canonicalSignedInfo.CleanXml()).ToBase64String();

        var signatureValue = CreateSignatureValueXml(signature);

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
                            {signatureValue}
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

        return soapEnvelope.CleanXml();
    }


    public string BuildQuery(DateTimePeriod queryPeriod, string rfcIssuer, string rfcReceiver, string requestType)
    {
        var signerRfc = credential.Certificate.Rfc;


        var toDigest =
            @$"<des:SolicitaDescarga xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"">
	                <des:solicitud RfcSolicitante=""rfcSolicitante"" FechaInicial=""fechaInicial"" FechaFinal=""fechaFinal"" TipoSolicitud=""CFDI"">
		                <des:RfcReceptores>
			                <des:RfcReceptor>{rfcReceiver}</des:RfcReceptor>
		                </des:RfcReceptores>
	                </des:solicitud>
            </des:SolicitaDescarga>";

        var digest = credential.CreateHash(toDigest.CleanXml());

        var canonicalSignedInfo = CreateCanonicalSignedInfoXml(digest);

        var signature = credential.SignData(canonicalSignedInfo.CleanXml()).ToBase64String();


        var soapEnvelope =
            @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" xmlns:des=""http://DescargaMasivaTerceros.sat.gob.mx"" xmlns:xd=""http://www.w3.org/2000/09/xmldsig#"">
                <s:Header/>
	                <s:Body>
		                <des:SolicitaDescarga>
			                <des:solicitud RfcEmisor=""{rfcIssuer}"" RfcSolicitante=""{signerRfc}"" FechaInicial=""{queryPeriod.StartDateSat}"" FechaFinal=""{queryPeriod.EndDateSat}"" TipoSolicitud=""{requestType}"">
				                <des:RfcReceptores>
					                <des:RfcReceptor>{rfcReceiver}</des:RfcReceptor>
				                </des:RfcReceptores>
                                <Signature xmlns=""http://www.w3.org/2000/09/xmldsig#"">
					                <SignedInfo>
						                <CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
						                <SignatureMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>
						                <Reference URI=""#_0"">
							                <Transforms>
								                <Transform Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
							                </Transforms>
							                <DigestMethod Algorithm=""http://www.w3.org/2000/09/xmldsig#sha1""/>
							                <DigestValue>digest</DigestValue>
						                </Reference>
					                </SignedInfo>
                                        <SignatureValue>signature</SignatureValue>
					                <KeyInfo>
						                <X509Data>
							                <X509IssuerSerial>
								                <X509IssuerName>{credential.Certificate.Issuer}</X509IssuerName>
								                <X509SerialNumber>{credential.Certificate.SerialNumber}</X509SerialNumber>
							                </X509IssuerSerial>
							                <X509Certificate>Convert.ToBase64String(certificate.RawData)</X509Certificate>
						                </X509Data>
					                </KeyInfo>
				                </Signature>
                            </des:solicitud>
		                </des:SolicitaDescarga>
	                </s:Body>
            </s:Envelope>";


        return soapEnvelope.CleanXml();
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

    private static string CreateSignatureValueXml(string signature)
    {
        return $"<SignatureValue>{signature}</SignatureValue>";
    }

    #endregion
}