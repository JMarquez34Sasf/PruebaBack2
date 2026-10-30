using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService service;
        public CuentaController(ICuentaService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseCuenta>> CreateCuenta(CreateCuenta dto)
        {
            var cuenta = await service.CreateService(dto);
            var respuesta = new ResponseGenerico<ResponseCuenta>
            {
                Codigo = 201,
                Message = "Cuenta Creada",
                Response = cuenta
            };
            return Ok(respuesta);
        }
        [HttpGet]
        public async Task<ActionResult<List<ResponseCuenta>>> GetCuentas()
        {
            var cuenta = await service.GetService();
            var respuesta = new ResponseGenerico<List<ResponseCuenta>>
            {
                Codigo = 200,
                Message = "Cuentas",
                Response = cuenta
            };
            return Ok(respuesta);
        }

    }
}
