using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class EffectsRepository : IEffectsRepository
    {
        private readonly ApplicationDbContext _context;

        public EffectsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            _context.Effects.Add(entity as EffectsDataEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            EffectsDataEntity entity = GetById(id) as EffectsDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            Update(entity);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return _context.Effects.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return _context.Effects.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            _context.Effects.Update(entity as EffectsDataEntity);
            _context.SaveChanges();
        }
    }
}
