using API.Core.Business.DBContext;
using API.Data.Core.Repository;
using API.Data.Core.Repository.Class;
using API.Data.Core.Repository.InterfaceRepo;
using Microsoft.Extensions.Logging;

namespace API.Uses.Cases.UOWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IClientesRepository ClienteRepo { get; private set; }
        public IVentaRepository VentaRepo { get; private set; }
        public IVehiculoRepository VehiculoRepo { get; private set; }
        public IUsuarioRepository UsuarioRepo { get; private set; }
        

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            ClienteRepo = new ClienteRepostory(context, _logger);
            VentaRepo = new VentaRepository(context, _logger);
            VehiculoRepo = new VehiculoRepository(context, _logger);
            UsuarioRepo = new UsuarioRepository(context, _logger);
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
