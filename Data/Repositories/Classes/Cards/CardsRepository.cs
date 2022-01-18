using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces.Cards;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class CardsRepository : ICardsRepository
    {

        private readonly ApplicationDbContext _context;

        public CardsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            _context.Add(entity as CardsDataEntity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            CardsDataEntity cardsDataEntity = GetById(id) as CardsDataEntity;
            cardsDataEntity.IsDeleted = true;
            cardsDataEntity.DeletedOn = DateTime.Now;
            Update(cardsDataEntity);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return _context.Cards.Find(id);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return _context.Cards.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            _context.Cards.Update(entity as CardsDataEntity);
            _context.SaveChanges();
        }
    }
}
