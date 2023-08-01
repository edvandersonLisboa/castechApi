using System;
using System.ComponentModel.DataAnnotations;

namespace QrCode.Api.Entities
{
    public class CertificadoEntity
    {
        [Key]
        public int Id { get; set; }
        public string? CodCertificado { get; set; }
        public string? UrlCertificado { get; set; }

        public DateTime? Validade { get; set; }

    }
}
