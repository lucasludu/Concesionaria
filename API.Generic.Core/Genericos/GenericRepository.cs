using API.Core.Business.DBContext;
using API.Middleware.Core.Logger;

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

        #region Delete
        public void Delete(int? id)
        {
            _logger.Warning("Buscando por ID.");
            var entity = GetById(id);//se fija si existe el campo
            try
            {
                _logger.Info("Delete --> ENTIDAD BORRADA");
                _db.Set<T>().Remove(entity);
            }
            catch
            {
                _logger.Error("Delete --> DELETE ERROR.");
                throw new Exception("No se encontro objeto");
            }
        }
        #endregion

        #region GetAll
        public IEnumerable<T> GetAll()
        {
            var type = _db.Set<T>().ToList();
            if(type == null)
            {
                _logger.Error("Get All --> NULL");
                return type;
            }
            _logger.Info("Get All --> Trae toda la entidad");
            return type;
        }
        #endregion

        #region GetById
        public T GetById(int? id)
        {
            _logger.Info("Get ID --> Entidad Encontrada");
            var aux = _db.Set<T>().Find(id);
            return aux;
        }
        #endregion

        #region Insert
        public void Insert(T entity)
        {
            _logger.Info("Insert --> Agrega un Campo Nuevo");
            _db.Set<T>().Add(entity);//agrega un campo nuevo
        }
        #endregion

        #region Update
        public void Update(T entity)
        {
            _logger.Info("Update --> Modifica el Campo.");
            _db.Set<T>().Update(entity);
        }
        #endregion

    }
}
