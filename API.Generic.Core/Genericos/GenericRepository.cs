using API.Core.Business.DBContext;
using API.Middleware.Core.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Generic.Core.Genericos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext _db;
        protected readonly LoggerCustom _logger;

        public GenericRepository(AppDbContext db, LoggerCustom logger)
        {
            _db = db;
            _logger = logger;
        }

        public void Delete(int? id)
        {
            _logger.Warning("\nBuscando por ID.");
            var entity = GetById(id);//se fija si existe el campo
            if (entity == null)
            {
                _logger.Error("Delete --> DELETE ERROR.");
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                _logger.Info("Delete --> ENTIDAD BORRADA");
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }

        }

        public IEnumerable<T> GetAll()
        {
            _logger.Info(@"Get All --> Trae toda la entidad");
            return _db.Set<T>().ToList();//llama todos la lista de elementos
        }

        public T GetById(int? id)
        {
            _logger.Info("Get ID --> Consulta el dato llamado");
            var aux = _db.Set<T>().Find(id);//trae cosa de la base de datos
            return aux;
        }

        public void Insert(T entity)
        {
            _logger.Info("Insert --> Agrega un Campo Nuevo");
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }

        public void Update(T entity)
        {
            _logger.Info("Update --> Modifica el Campo.");
            _db.Set<T>().Update(entity);//modifica campo exisente
        }
    }
}
