using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Intrefaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class EffectTypesRepository : IEffectTypesRepository
    {

        private readonly ApplicationDbContext _context;

        public EffectTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            _context.EffectTypes.Add(entity as EffectTypesDataEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            EffectTypesDataEntity entity = GetById(id) as EffectTypesDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            Update(entity);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return _context.EffectTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return _context.EffectTypes.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            _context.EffectTypes.Update(entity as EffectTypesDataEntity);
            _context.SaveChanges();
        }
    }
}
