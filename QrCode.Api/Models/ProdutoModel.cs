using System;

namespace QrCode.Api.Models
{
    public class ProdutoModel
    {
        public string Name { get; set; }
        public int? Quantidade { get; set; }
        public string Peso { get; set; }
        public string Cliente { get; set; }
        public string CodProduto { get; set; }
        public string DataExtracao { get; set; }
        public string DataVenda { get; set; }
        public byte[] Qrcode { get; set; }
        public string Url { get; set; }
        public string UrlQrCode { get; set; }
    }
}
