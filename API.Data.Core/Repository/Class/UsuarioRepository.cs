using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;
using API.Middleware.Core.Logger;
using Microsoft.Extensions.Logging;

namespace API.Data.Core.Repository.Class
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext db, LoggerCustom logger) : base(db, logger)
        {
        }

        public Usuario GetByEmail(string email)
        {
            return _db.Usuarios.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            return _db.Usuarios.Any(a => a.Email == email);
        }
    }
}
