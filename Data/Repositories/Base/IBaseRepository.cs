using Data.Common;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        public void Create(IBaseDataEntity<T> entity);

        public IEnumerable<IBaseDataEntity<T>> GetAll();

        public IBaseDataEntity<T> Get(T id);

        public void Update(IBaseDataEntity<T> entity);

        public void Delete(T id);
    }
}
