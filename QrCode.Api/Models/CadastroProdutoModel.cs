using System;
using System.Collections.Generic;
using System.Drawing;

namespace QrCode.Api.Models
{
    public class CadastroProdutoModel
    {
        public string Name { get; set; }
        public int Quantidade { get; set; }
        public string Peso { get; set; }
        public string Cliente { get; set; }
        public string CodProduto { get; set; }
        public string DataExtracao { get; set; }
        public string DataVenda { get; set; }
        public string Url { get; set; }
        public CertificadoModel Certificado { get; set; }
       
    }
}
