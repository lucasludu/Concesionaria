using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;
using API.Middleware.Core.Logger;
using Microsoft.Extensions.Logging;

namespace API.Data.Core.Repository
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(AppDbContext db, LoggerCustom logger) : base(db, logger)
        {

        }
    }

}
