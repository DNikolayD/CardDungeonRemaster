using Data.Common;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes
{
    public class DeckTypesRepository : IDeckTypesRepository
    {

        private readonly ApplicationDbContext _context;

        public DeckTypesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            this._context.DeckTypes.Add(entity as DeckTypesDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            DeckTypesDataEntity entity = this.GetById(id) as DeckTypesDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return this._context.DeckTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return this._context.DeckTypes.Where(d => !d.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Update(entity);
            this._context.SaveChanges();
        }
    }
}
