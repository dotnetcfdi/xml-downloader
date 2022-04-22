﻿using System;
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

    public string Authenticate(TokenPeriod tokenPeriod, string securityTokenId = "")
    {
        securityTokenId = string.IsNullOrEmpty(securityTokenId) ? CreateXmlSecurityTokenId() : securityTokenId;
        var certB64 = credential.Certificate.RawDataBytes.ToBase64String();


        var timeStamp =
            @$"<u:Timestamp u:Id=""_0"">
                    <u:Created>{tokenPeriod.Created}</u:Created>
                    <u:Expires>{tokenPeriod.Expires}</u:Expires>
                </u:Timestamp>";

        var digest = credential.CreateHash(Helper.CleanXml(timeStamp));


        var canonicalSignedInfo =
            $@"<SignedInfo>
                    <CanonicalizationMethod Algorithm=""http://www.w3.org/2001/10/xml-exc-c14n#""/>
                    <SignatureMethod Algorithm = ""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>
                    <Reference URI = ""#_0"">
                        <Transforms>
                            <Transform Algorithm = ""http://www.w3.org/2001/10/xml-exc-c14n#""/>
                        </Transforms>
                        <DigestMethod Algorithm = ""http://www.w3.org/2000/09/xmldsig#sha1""/>
                        <DigestValue>{digest}</DigestValue>
                    </Reference>
                </SignedInfo>";

        var signature = credential.SignData(Helper.CleanXml(canonicalSignedInfo)).ToBase64String();

        var soapEnvelope =
            @$"<? xml version = ""1.0"" encoding = ""utf-8"" ?>
             <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" >
                <s:Header>
                    <o:Security s:mustUnderstand = ""1"" xmlns: o = ""http: //docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                        <u:Timestamp u:Id = ""_0"">
                            <u:Created>{tokenPeriod.Created}</u:Created>
                            <u:Expires>{tokenPeriod.Expires}</u:Expires>
                        </u:Timestamp>
                        <o:BinarySecurityToken u:Id = ""uuid"" ValueType =""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" EncodingType =""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"" >
                            {certB64}
                        </o:BinarySecurityToken>
                        <Signature xmlns = ""http://www.w3.org/2000/09/xmldsig#"" >
                         <SignedInfo >
                            <CanonicalizationMethod Algorithm = ""http://www.w3.org/2001/10/xml-exc-c14n#""/>
                            <SignatureMethod Algorithm = ""http://www.w3.org/2000/09/xmldsig#rsa-sha1""/>
                            <Reference URI = ""#_0"" >
                                <Transforms>
                                    <Transform Algorithm = ""http://www.w3.org/2001/10/xml-exc-c14n#""/>
                                </Transforms>
                                <DigestMethod Algorithm = ""http://www.w3.org/2000/09/xmldsig#sha1""/>
                                <DigestValue>{digest}</DigestValue>
                            </Reference>
                         </SignedInfo>
                        <SignatureValue>{signature}</SignatureValue>
                        <KeyInfo>
                            <o:SecurityTokenReference>
                                <o:Reference ValueType =""http: //docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" URI =""#{securityTokenId}""/>
                            </o:SecurityTokenReference>
                        </KeyInfo>
                        </Signature>
                    </o:Security>
                </s:Header>
                <s:Body>
                    <Autentica xmlns = ""http://DescargaMasivaTerceros.gob.mx""/>
                </s:Body>
            </s:Envelope>";

        return soapEnvelope;
    }

    private static string CreateXmlSecurityTokenId()
    {
        return $"uuid-{Guid.NewGuid().ToString()}-1";
    }
}