using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;
using Microsoft.Extensions.Logging;

namespace API.Data.Core.Repository
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        public VentaRepository(AppDbContext db, ILogger logger) : base(db, logger)
        {

        }
    }
}
