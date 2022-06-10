using API.Core.Business.Authentication.Request;
using API.Core.Business.Authentication.Response;
using API.Core.Business.Filtros;
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
        private readonly ILogger<LoginController> _logger;

        public LoginController(IUsuarioService userService, IUnitOfWork uOw)
        {
            _userService = userService;
            _uOw = uOw;
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
                return Unauthorized();
            }

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
                return BadRequest("Ya existe una cuenta asociada con este email");
            }

            UserResponse res = _userService.Registrar(req, req.Password);
            return Ok(res);
        }
        #endregion


    }
}
