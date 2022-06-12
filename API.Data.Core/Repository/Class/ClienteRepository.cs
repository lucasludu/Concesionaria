using API.Core.Business.DBContext;
using API.Core.Business.Entities;
using API.Data.Core.Repository.InterfaceRepo;
using API.Generic.Core.Genericos;
using API.Middleware.Core.Logger;
using Microsoft.Extensions.Logging;

namespace API.Data.Core.Repository
{
    public class ClienteRepostory : GenericRepository<Cliente>, IClientesRepository
    {
        public ClienteRepostory(AppDbContext db, LoggerCustom logger) : base(db, logger)
        {

        }
    }
}
