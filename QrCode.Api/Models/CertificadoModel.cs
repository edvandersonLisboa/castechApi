using System;
using System.Security.Policy;

namespace QrCode.Api.Models
{
    public class CertificadoModel
    {
        public string CodCertificado { get; set; }
        public string UrlCertificado { get; set; }
        public string Validade { get; set; }
    }
}
