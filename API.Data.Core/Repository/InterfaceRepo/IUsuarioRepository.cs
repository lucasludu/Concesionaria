using API.Core.Business.Entities;
using API.Generic.Core.Genericos;

namespace API.Data.Core.Repository.InterfaceRepo
{

    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario GetByEmail(string email);
        bool ExisteUsuario(string email);
    }
}

