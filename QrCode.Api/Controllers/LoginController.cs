using Microsoft.AspNetCore.Mvc;
using QrCode.Api.Models;
using QrCode.Api.Repositories;
using QrCode.Api.Services;
using System;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace QrCode.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult<dynamic>> AutheticationAsync([FromBody] User model)
        {
            //Recuperar Usuario
            var user = UserRepository.Get(model.Username, model.Password);

            //Verificar usuario
            if(user == null)
            {
                return  new { message = "Usuario não encontrado"};
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new {user = user, token = token};

        }
    }
}
