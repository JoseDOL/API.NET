using APIRest.Models;
using APIRest.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [Authorize] 
    [ApiController]
    public class OperacionesController(IServicioConexion servicioConexion) : ControllerBase
    {
        private readonly IServicioConexion servicioConexion = servicioConexion;

        [HttpGet("readData")]
        public async Task<JsonResult> readData()
        {
            var result = await servicioConexion.EObetener();

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        [HttpPost("addData")]
        public async Task<IActionResult> addData([FromBody] Persona persona)
        {
            var resultado = await servicioConexion.Crear(persona);
            if (resultado == -1)
            {
                return Ok(new { message = "Persona insertada correctamente" });
            }
            return StatusCode(500, new { message = $"Error al insertar persona: {persona.Nombre}" } );
        }

        

        [HttpPost("searchPerson")]
        public async Task<IActionResult> searchPerson([FromBody] string persona)
        {
            var resultado = await servicioConexion.buscarPersona(persona);
            return new JsonResult(resultado)
            {
                StatusCode = StatusCodes.Status200OK 
            };
        }

        [HttpPut("updateData")]
        public async Task updateData([FromBody] Persona persona)
        {
            var resultado = await servicioConexion.Update(persona);

        }

        [HttpDelete("deleteData")]
        public async Task deleteData([FromBody] PersonId persona)
        {
            var resultado = await servicioConexion.Eliminar(persona);

        }
    }
}
