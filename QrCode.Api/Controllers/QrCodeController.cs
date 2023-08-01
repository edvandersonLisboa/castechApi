using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QrCode.Api.Entities;
using QrCode.Api.Infrastructures;
using QrCode.Api.Models;
using QrCode.Api.Services;
using System;
using System.Linq;

namespace QrCode.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QrCodeController : ControllerBase
    {
        protected readonly QrCodeDbContext context;
        protected DbSet<ProdutoEntity> DbSet;
        public QrCodeController(QrCodeDbContext context)
        {
            this.context = context;
            DbSet = context.Set<ProdutoEntity>();
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult MostraQrcode(int id)
        {
            ProdutoEntity prod = DbSet.Find(id);
            return File(prod.Qrcode, "image/jpeg");
        }
        



    }
}
