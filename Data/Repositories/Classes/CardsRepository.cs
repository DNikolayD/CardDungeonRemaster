using Data.Common;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes
{
    public class CardsRepository : ICardsRepository
    {

        private readonly ApplicationDbContext _context;

        public CardsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Add(entity as CardsDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            CardsDataEntity cardsDataEntity = this.GetById(id) as CardsDataEntity;
            cardsDataEntity.IsDeleted = true;
            cardsDataEntity.DeletedOn = DateTime.Now;
            this.Update(cardsDataEntity);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Cards.Find(id);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Cards.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Cards.Update(entity as CardsDataEntity);
            this._context.SaveChanges();
        }
    }
}
