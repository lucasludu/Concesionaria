
#region USING
using API.Core.Business.Authentication.Request;
using API.Core.Business.Authentication.Response;
using API.Core.Business.Entities;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
#endregion USING

namespace API.Uses.Cases.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _uOw;
        private readonly IConfiguration _config;

        public UsuarioService(IUnitOfWork uow, IConfiguration config)
        {
            _uOw = uow;
            _config = config;
        }

        #region GenerarToken
        public string GetToken(UserResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        #endregion GenerarToken

        #region Login
        public UserResponse Login(string email, string password)
        {
            if(_uOw.UsuarioRepo.ExisteUsuario(email))
            {
                UserResponse response = new UserResponse();

                // Traigo al usuario por el email
                Usuario user = _uOw.UsuarioRepo.GetByEmail(email);

                // Verifico si existe el password ingresado y que coinsida con el de la BBDD
                if(!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }

                // Se mappea a un UserResponse
                response.Email = email;
                response.UserName = user.UserName;
                response.Id = user.Id;
                response.Role = user.Role;

                return response;
            }
            return null;
        }
        #endregion Login

        #region VerificarPassword
        private bool VerificarPassword(string password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            // Se encripta con la key (passwordSalt)
            var hMac = new HMACSHA512(passwordSalt);
            var hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Comparo el password de la BBDD con el que se acaba de encriptar
            for(var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i]) return false;
            }
            return true;
        }
        #endregion VerificarPassword

        #region CrearHashPass
        private void CrearPassHash(string pass, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Creo una encriptacion
            var hMac = new HMACSHA512();
            // Se le asigna la llave de la incriptacion al passwordSalt
            passwordSalt = hMac.Key;
            // Se encripta el pass y lo guardo en passwordHash
            passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(pass));
        }
        #endregion CrearHashPass

        #region Registrar
        public UserResponse Registrar(UserRequest usuario, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPassHash(password, out passwordHash, out passwordSalt);

            Usuario user = new Usuario();
            user.UserName = usuario.UserName;
            user.Email = usuario.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = Role.Admin;
            _uOw.UsuarioRepo.Insert(user);
            _uOw.Save();

            UserResponse response = new UserResponse();
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Id = user.Id;
            response.Role = user.Role;

            return response;
        }
        #endregion Registrar
    }
}
