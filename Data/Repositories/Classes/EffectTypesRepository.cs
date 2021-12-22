using Data.Common;
using Data.Entities;
using Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes
{
    public class EffectTypesRepository : IBaseRepository<int>
    {

        private readonly ApplicationDbContext _context;

        public EffectTypesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            this._context.EffectTypes.Add(entity as EffectTypesDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            EffectTypesDataEntity entity = this.Get(id) as EffectTypesDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IBaseDataEntity<int> Get(int id)
        {
            return this._context.EffectTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return this._context.EffectTypes.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.EffectTypes.Update(entity as EffectTypesDataEntity);
            this._context.SaveChanges();
        }
    }
}
