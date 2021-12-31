using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class DeckTypesRepository : IDeckTypesRepository
    {

        private readonly ApplicationDbContext _context;

        public DeckTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            _context.DeckTypes.Add(entity as DeckTypesDataEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            DeckTypesDataEntity entity = GetById(id) as DeckTypesDataEntity;
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            Update(entity);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return _context.DeckTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return _context.DeckTypes.Where(d => !d.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
