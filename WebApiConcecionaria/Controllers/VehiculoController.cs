using API.Core.Business.Entities;
using API.Middleware.Core.Logger;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VentaDeVehiculo.Controllers
{
    [Authorize]
    [Tags("Api de Vehiculo")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        private readonly ILogger<VehiculoController> _logger;
        private LoggerCustom loggerCustom { get; set; }

        public VehiculoController(IUnitOfWork context, ILogger<VehiculoController> logger)
        {
            _context = context;
            _logger = logger;
            loggerCustom = new LoggerCustom(_logger);
        }


        #region GET
        /// <summary>
        /// Muestra todos los vehiculos
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Vehiculo>> Get()
        {
            loggerCustom.Info("[Get] Vehiculo");
            var entidad = _context.VehiculoRepo.GetAll();
            return Ok(entidad);
        }
        #endregion


        #region POST
        /// <summary>
        /// Crea el vehiculo
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="vehiculo">Vehiculo a ingresar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehiculo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] Vehiculo vehiculo)
        {
            loggerCustom.Info("[Post] Vehiculo");
            _context.VehiculoRepo.Insert(vehiculo);
            _context.Save();
            return Ok();
        }
        #endregion


        #region PUT
        /// <summary>
        /// Modifica el vehiculo
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">Vehiculo a modificar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehiculo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put([FromBody] Vehiculo vehiculo, int? id)
        {
            if (id != vehiculo.Id)
            {
                loggerCustom.Error("No se encuentra el registro");
                return BadRequest();
            }
            loggerCustom.Info("[Put] Vehiculo");
            _context.VehiculoRepo.Update(vehiculo);
            _context.Save();
            return Ok();
        }
        #endregion


        #region DELETE
        /// <summary>
        /// Elimina al vehiculo
        /// </summary>
        /// <remarks>Awesomeness!</remarks>
        /// <param name="id" example="123">Vehiculo a eliminar</param>
        /// <response code="200">Created. Objeto correctamente creado en la BBDD</response>
        /// <response code="400">BadRequest. No se ha creado el objeto en la BBDD. Formato del objeto incorrecto</response>
        /// <response code="500">Unauthorized. Error interno dentro de la funcion</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Vehiculo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            var entity = _context.VehiculoRepo.GetById(id);
            if (entity == null)
            {
                loggerCustom.Error("No se encuentra el registro solicitado");
                return NotFound("No se encuentra el registro solicitado");
            }
            loggerCustom.Info("[Delete] Vehiculo");
            _context.VehiculoRepo.Delete(id);
            _context.Save();
            return Ok();
        }
        #endregion


    }
}
