using System.Security.Cryptography;
using System.Text;
using Credencials.Common;
using Credencials.Core;
using XmlDownloader.Common;

namespace XmlDownloader.RequestBuilder
{
    internal class RequestBuilder : IRequestBuilder
    {
        private readonly ICredential credential;

        public RequestBuilder(ICredential credential)
        {
            this.credential = credential;
        }

        public string Authorization(string created, string expires, string securityTokenId = "")
        {
            var uuid = CreateXmlSecurityTokenId();
            var certB64 = credential.Certificate.RawDataBytes.ToBase64String();


            var timeStamp =
                @$"<u:Timestamp u:Id=""_0"">
                    <u:Created>{created}</u:Created>
                    <u:Expires>{expires}</u:Expires>
                </u:Timestamp>";

            var digest = credential.CreateHash(timeStamp);


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

            var signature = credential.SignData(canonicalSignedInfo).ToBase64String();

            var soapMessage =
                $@"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" >
                <s:Header>
                    <o:Security s:mustUnderstand = ""1"" xmlns: o = ""http: //docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                        <u:Timestamp u:Id = ""_0"">
                            <u:Created>{created}</u:Created>
                            <u:Expires>{expires}</u:Expires>
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
                                <o:Reference ValueType =""http: //docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3"" URI =""#{uuid}""/>
                            </o:SecurityTokenReference>
                        </KeyInfo>
                        </Signature>
                    </o:Security>
                </s:Header>
                <s:Body>
                    <Autentica xmlns = ""http://DescargaMasivaTerceros.gob.mx""/>
                </s:Body>
                </s:Envelope>";

            return soapMessage;
        }


        private string CreateXmlSecurityTokenId()
        {
            return $"uuid-{Guid.NewGuid().ToString()}-1";
        }
    }
}