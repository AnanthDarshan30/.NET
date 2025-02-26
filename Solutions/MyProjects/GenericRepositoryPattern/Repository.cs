using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepositoryPattern;

namespace GenericRepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly List<T> _dataStore = new List<T>();
        public IEnumerable<T> GetAll()
        {
            return _dataStore;
        }
        public T GetById(int id)
        {
            return _dataStore.FirstOrDefault(e => e.Id == id);
        }
        public void Add(T entity)
        {
            _dataStore.Add(entity);
        }
        public void Update(T entity)
        {
            T existingEntity = GetById(entity.Id);
            if (existingEntity != null)
            {
                _dataStore.Remove(existingEntity);
                _dataStore.Add(entity);
            }   
        }
        public void Delete(int id)
        {
            T entity = GetById(id);
            if(entity != null)
            {
                _dataStore.Remove(entity);
            }
        }
    }
}
