using Codigos.Modelo.Entidades.Generales;
using Codigos.Negocio.Negocios;
using Microsoft.AspNetCore.Mvc;

namespace FHL_SGD_Codigos_Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "ValidadorNuevosRegistros")]
    public class ValidarNuevosRegistrosController : Controller
    {
        private ValidarNuevosRegistrosBusiness _bss { get; set; } = new();

        /// <summary>
        /// Metodo para validar si existen nuevos registros y si hay alguno que necesite imagenes QR o BC
        /// </summary>
        /// <remarks>
        ///     <p>Ejemplo de Fecha con hora: 2024-03-11T12:00:00.000</p>
        ///     <p>La fecha se obtiene del servicio de Windows que la toma del sistema operativo </p>
        ///</remarks>
        /// <param name="FechaHoraValidacion"></param>
        /// <returns>Retorna una Respuesta, dependiendo si fue exitosa tendra estatus 200 (Exitoso) o 500 (Error del servidor, tanto de la base de datos o el servidor de imagenes) </returns>
        /// <response code="200">Retorna que se ha ejecutado correctamente el proceso o que no había ningun registro nuevo por crear.</response>
        /// <response code="400">Retorna un error ya que no se han enviado las imagenes codigos necesarias para crear registros en la BD.</response>
        /// <response code="500">Retorna un error ya que ha ocurrido al tratar de construir la llamada a los diferentes SP validadores o al momento de la ejecución. 
        /// También ocurre por problemas con el servidor donde se guardan las imagenes al no encontrar el Directorio.</response>
        [HttpGet("Validar/{FechaHoraValidacion}")]
        [ProducesResponseType(typeof(Respuesta), 200)]
        [ProducesResponseType(typeof(Respuesta), 400)]
        [ProducesResponseType(typeof(Respuesta), 500)]
        [Produces("application/json")]
        [FormatFilter]
        public async Task<IActionResult> ValidarNuevosRegistros(DateTime FechaHoraValidacion)
        {
            var result = await _bss.ValidarNuevosRegistros(FechaHoraValidacion);

            if (result.Status == 200)
            {
                return Ok(result); // Retorna un 200 con el resultado return Ok(result); // Retorna un 200 con el resultado
            }
            else if (result.Status == 400)
            {
                // Si la validación falla, se retorna un 400 con el mensaje de error
                return BadRequest(new Respuesta
                {
                    Status = 400,
                    Message = result.Message,
                    TotalRows = result.TotalRows,
                    PageIndex = result.PageIndex,
                    PageSize = result.PageSize,
                    Data = result.Data
                });
            }
            else {
                // Para cualquier otra excepción, se retorna un 500 con el mensaje de error
                return StatusCode(500, new Respuesta
                {
                    Status = 500,
                    Message = result.Message,
                    TotalRows = result.TotalRows,
                    PageIndex = result.PageIndex,
                    PageSize = result.PageSize,
                    Data = result.Data
                });
            }
        }
    }
}
