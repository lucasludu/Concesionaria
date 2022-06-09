using API.Core.Business.DBContext;
using API.Data.Core.Repository;
using API.Data.Core.Repository.Class;
using API.Data.Core.Repository.InterfaceRepo;

namespace API.Uses.Cases.UOWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IClientesRepository ClienteRepo { get; private set; }

        public IVentaRepository VentaRepo { get; private set; }

        public IVehiculoRepository VehiculoRepo { get; private set; }
        public IUsuarioRepository UsuarioRepo { get; private set; }
        


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ClienteRepo = new ClienteRepostory(context);
            VentaRepo = new VentaRepository(context);
            VehiculoRepo = new VehiculoRepository(context);
            UsuarioRepo = new UsuarioRepository(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
