using API.Core.Business.Entities;
using API.Middleware.Core.Logger;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentaDeVehiculo.Controllers
{
    [Authorize]
    [Tags("Api de Venta")]
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<VentaController> _logger;
        private LoggerCustom loggerCustom { get; set; }

        public VentaController(IUnitOfWork context, ILogger<VentaController> logger)
        {
            _context = context;
            _logger = logger;
            loggerCustom = new LoggerCustom(_logger);
        }

        #region GET
        /// <summary>
        /// Muestra toda la venta
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Venta>> Get()
        {
            loggerCustom.Info("[Get] Venta");
            var entidad = _context.VentaRepo.GetAll();
            return Ok(entidad);
        }
        #endregion


        #region POST
        /// <summary>
        /// Crea la venta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="venta">Venta a ingresar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] Venta venta)
        {
            loggerCustom.Info("[Post] Venta");
            _context.VentaRepo.Insert(venta);
            _context.Save();
            return Ok();
        }
        #endregion


        #region PUT
        /// <summary>
        /// Modifica a la venta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">Venta a modificar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put([FromBody] Venta venta, int? id)
        {
            if (id != venta.Id)
            {
                loggerCustom.Error("No se encuentra el registro");
                return BadRequest();
            }
            loggerCustom.Info("[Put] Venta");
            _context.VentaRepo.Update(venta);
            _context.Save();
            return Ok();
        }
        #endregion


        #region DELETE
        /// <summary>
        /// Elimina a la venta
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">Venta a eliminar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Venta))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            var entity = _context.VentaRepo.GetById(id);
            if (entity == null)
            {
                loggerCustom.Error("No se encuentra el registro solicitado");
                return NotFound("No se encuentra el registro solicitado");
            }
            loggerCustom.Info("[Delete] Venta");
            _context.VentaRepo.Delete(id);
            _context.Save();
            return Ok();
        }
        #endregion


    }
}
