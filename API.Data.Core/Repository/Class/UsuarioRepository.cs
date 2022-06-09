using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;

namespace API.Data.Core.Repository.Class
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext db) : base(db)
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
