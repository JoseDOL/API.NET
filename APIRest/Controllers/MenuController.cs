using APIRest.Models;
using APIRest.Servicios;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController(IServicioConexion servicioConexion) : ControllerBase
    {

        private readonly IServicioConexion servicioConexion = servicioConexion;

        // GET: api/<MenuController>
        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var result = await servicioConexion.ObtenerNav();

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK // Status code here 
            };
        }
    }
}
