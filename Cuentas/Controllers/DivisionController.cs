using Cuentas.Interfaces;
using Cuentas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cuentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IDivisionService service;
        public DivisionController(IDivisionService service)
        {

            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Division>>> Get()
        {
            var division = await service.Get();
            var respuesta = new ResponseGenerico<List<Division>>
            {
                Codigo = 200,
                Message = "Divisiones",
                Response = division
            };
            return Ok(respuesta);
        }
    }
}
