using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService service;
        public MonedaController(IMonedaService service)
        {
            this.service= service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Monedum>>> Get()
        {
            var monedas = await service.Get();
            var respuesta = new ResponseGenerico<List<Monedum>>
            {
                Codigo = 200,
                Message = "Monedas",
                Response = monedas
            };
            return Ok(respuesta);
        }
    }
}
