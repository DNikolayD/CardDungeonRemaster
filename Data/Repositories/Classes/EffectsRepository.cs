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
    public class EffectsRepository : IBaseRepository<int>
    {
        private readonly ApplicationDbContext _context;

        public EffectsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            this._context.Effects.Add(entity as EffectsDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            EffectsDataEntity entity = this.Get(id) as EffectsDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IBaseDataEntity<int> Get(int id)
        {
            return this._context.Effects.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return this._context.Effects.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Effects.Update(entity as EffectsDataEntity);
            this._context.SaveChanges();
        }
    }
}
