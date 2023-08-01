using QrCode.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace QrCode.Api.Entities
{
    public class ProdutoEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public int? Quantidade { get; set; }
        public string? Peso { get; set; }
        public string? Cliente { get; set; }
        public string? CodProduto { get; set; }
        public DateTime? DataExtracao { get; set; }
        public DateTime? DataVenda { get; set; }
        public byte[] Qrcode { get; set; }
        public string Url { get; set; }
        public string UrlQrCode { get; set; }
        public IList<CertificadoEntity> Certificados { get; set; }
    }
}
