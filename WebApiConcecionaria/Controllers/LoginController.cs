using API.Core.Business.Authentication.Request;
using API.Core.Business.Authentication.Response;
using API.Core.Business.Filtros;
using API.Middleware.Core.Logger;
using API.Uses.Cases.Services;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Mvc;

namespace WebApiConcecionaria.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioService _userService;
        private readonly IUnitOfWork _uOw;
        private LoggerCustom loggerCustom { get; set; }
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUsuarioService userService, IUnitOfWork uOw, ILogger<LoginController> logger)
        {
            _userService = userService;
            _uOw = uOw;
            _logger = logger;
            loggerCustom = new LoggerCustom(_logger);
        }

        #region LOGIN
        /// <summary>
        /// Logueo de Usuario
        /// </summary>
        /// <param name="req">User Request</param>
        /// <returns>Usuario</returns>
        [HttpPost]
        public ActionResult Login([FromBody] UserRequest req)
        {
            var response = _userService.Login(req.Email, req.Password);

            if(response == null)
            {
                loggerCustom.Error("Error. Email y/o constraseña invalida.");
                return Unauthorized();
            }
            loggerCustom.Info("Se ha iniciado seción.");
            var token = _userService.GetToken(response);

            return Ok(new
            {
                token = token,
                usuario = response
            });
        }
        #endregion


        #region REGISTRAR USUARIO
        /// <summary>
        /// Se Registra al usuario
        /// </summary>
        /// <param name="req">User Request</param>
        /// <returns>Registro</returns>
        [HttpPost("Registro")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult RegistrarUsuario([FromBody] UserRequest req)
        {
            if(_uOw.UsuarioRepo.ExisteUsuario(req.Email.ToLower()))
            {
                loggerCustom.Error("Ya existe una cuenta asociada con este email");
                return BadRequest("Ya existe una cuenta asociada con este email");
            }

            loggerCustom.Info("Se ha registrado correctamente.");
            UserResponse res = _userService.Registrar(req, req.Password);
            return Ok(res);
        }
        #endregion


    }
}
