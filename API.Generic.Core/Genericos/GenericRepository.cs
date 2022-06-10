using API.Core.Business.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Generic.Core.Genericos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly AppDbContext _db;
        protected readonly ILogger _logger;

        public GenericRepository(AppDbContext db, ILogger logger)
        {
            _db = db;
            _logger = logger;
        }

        public void Delete(int? id)
        {
            _logger.LogWarning("\nBuscando por ID.");
            var entity = GetById(id);//se fija si existe el campo
            if (entity == null)
            {
                _logger.LogError("Delete --> DELETE ERROR.");
                throw new Exception("No se encontro objeto");//en caso de que no exista
            }
            else
            {
                _logger.LogInformation("Delete --> ENTIDAD BORRADA");
                _db.Set<T>().Remove(entity);//en case de que exista, lo borra.
            }

        }

        public IEnumerable<T> GetAll()
        {
            _logger.LogInformation("Get All --> Trae toda la entidad");
            return _db.Set<T>().ToList();//llama todos la lista de elementos
        }

        public T GetById(int? id)
        {
            _logger.LogInformation("Get ID --> Consulta el dato llamado : {id}", DateTimeOffset.Now);
            var aux = _db.Set<T>().Find(id);//trae cosa de la base de datos
            return aux;
        }

        public void Insert(T entity)
        {
            _logger.LogInformation("Insert --> Agrega un Campo Nuevo");
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }

        public void Update(T entity)
        {
            _logger.LogInformation("Update --> Modifica el Campo.");
            _db.Set<T>().Update(entity);//modifica campo exisente
        }
    }
}
