using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class CardTypesRepository : ICardTypesRepository
    {

        private readonly ApplicationDbContext _context;

        public CardTypesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            _context.CardTypes.Add(entity as CardTypesDataEntity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            CardTypesDataEntity cardType = GetById(id) as CardTypesDataEntity;
            cardType.IsDeleted = true;
            cardType.DeletedOn = DateTime.Now;
            Update(cardType);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return _context.CardTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return _context.CardTypes.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.EditedOn = DateTime.Now;
            entity.IsEdited = true;
            _context.CardTypes.Update(entity as CardTypesDataEntity);
            _context.SaveChanges();
        }
    }
}
