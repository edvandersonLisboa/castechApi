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
            return new ObjectResult(prod);
        }
        [HttpGet]
        public IActionResult Produtos()
        {
            var prod = DbSet.AsNoTracking().ToList();
            return new ObjectResult(prod);
        }

    }
}
