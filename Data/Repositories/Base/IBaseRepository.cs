using Data.Entities.Common;
using System.Collections.Generic;

namespace Data.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        public void Create(IBaseDataEntity<T> entity);

        public IEnumerable<IBaseDataEntity<T>> GetAll();

        public IBaseDataEntity<T> GetById(T id);

        public void Update(IBaseDataEntity<T> entity);

        public void Delete(T id);
    }
}
