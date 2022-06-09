using API.Data.Core.Repository.InterfaceRepo;

namespace API.Uses.Cases.UOWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClientesRepository ClienteRepo { get; }
        IVentaRepository VentaRepo { get; }
        IVehiculoRepository VehiculoRepo { get; }
        IUsuarioRepository UsuarioRepo { get; }
        void Save();
    }
}
