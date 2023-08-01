using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrCode.Api.Entities;
using QrCode.Api.Infrastructures;
using QrCode.Api.Models;
using System.Globalization;
using System;
using System.Linq;

namespace QrCode.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdutoController: ControllerBase
    {

        protected readonly QrCodeDbContext context;
        protected DbSet<ProdutoEntity> DbSet;
        public ProdutoController(QrCodeDbContext context)
        {
            this.context = context;
            DbSet = context.Set<ProdutoEntity>();
        }

        [HttpGet("{id}")]
        public IActionResult ProdutoId(int id)
        {
            ProdutoEntity prod = DbSet.Find(id);
            return new ObjectResult(new ProdutoModel
            {
                Name = prod.Name,
                Quantidade = prod.Quantidade,
                Peso = prod.Peso,
                Cliente = prod.Cliente,
                CodProduto = prod.CodProduto,
                DataExtracao = prod.DataExtracao == null ? "" : DateTime.ParseExact(prod.DataExtracao.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString(),
                DataVenda = prod.DataVenda == null ? "" : DateTime.ParseExact(prod.DataVenda.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString(),
                Url = prod.Url,
                UrlQrCode = prod.UrlQrCode,
            });
        }
        [HttpGet]
        public IActionResult Produtos()
        {
            var prod = DbSet.AsNoTracking().ToList();
            return new ObjectResult(prod);
        }

    }
}
