using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using QrCode.Api.Entities;
using QrCode.Api.Infrastructures;
using QrCode.Api.Models;
using QrCode.Api.Models.error;
using QrCode.Api.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Policy;

namespace QrCode.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CadastroController: ControllerBase
    {
        protected readonly QrCodeDbContext context;
        protected DbSet<ProdutoEntity> DbSet;
        public CadastroController(QrCodeDbContext context)
        {
            this.context = context;
            DbSet = context.Set<ProdutoEntity>();
        }

        [HttpPost]
        //[Authorize(Roles ="employee,manager")]
        public IActionResult CadastroProduto(CadastroProdutoModel produto)
        {
            DateTime? date = null;



            if (produto == null)
            {
                return new OkObjectResult(new ErroModel { msg= "produto com todos os valores nulos!" });
            }
            
            ProdutoEntity prod = new ProdutoEntity()
            {
                Peso = produto.Peso,
                CodProduto = produto.CodProduto,
                Cliente = produto.Cliente,
                DataExtracao = produto.DataExtracao == "" ? null : DateTime.ParseExact(produto.DataExtracao.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DataVenda = produto.DataVenda == "" ? null : DateTime.ParseExact(produto.DataVenda.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Name = produto.Name,
                Quantidade = produto.Quantidade,
                Certificados = new List<CertificadoEntity>(),
                Url = "https://localhost:44359/api/QrCode/Produto/",
                Qrcode = null
            };

            prod.Certificados.Add(new CertificadoEntity (){ 
                UrlCertificado= produto.Certificado.UrlCertificado,
                CodCertificado = produto.Certificado.CodCertificado,
                Validade = produto.Certificado.Validade == "" ? date : DateTime.ParseExact(produto.Certificado.Validade.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),

            });

            
            var result = DbSet.Add(prod);
            context.SaveChanges();
            var image = QrCodeGenerator.GenerateByteArray($"https://localhost:44359/api/v1/Produto/{result.Entity.Id}");
            prod.Qrcode = image;
            prod.UrlQrCode = $"https://localhost:44359/api/v1/QrCode/{result.Entity.Id}";
            
            var entry = context.Entry(result.Entity);
            DbSet.Attach(prod);
            entry.State = EntityState.Modified;
            context.SaveChanges();



            return new OkObjectResult(result.Entity);
        }

       
    }
}
