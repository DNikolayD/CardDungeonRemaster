using Data.Entities;
using Data.Entities.Common;
using Data.Repositories.Intrefaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes.Cards
{
    public class DecksRepository : IDecksRepository
    {

        private readonly ApplicationDbContext _context;

        public DecksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            _context.Decks.Add(entity as DecksDataEntity);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            DecksDataEntity deck = GetById(id) as DecksDataEntity;
            deck.IsDeleted = true;
            deck.DeletedOn = DateTime.Now;
            Update(deck);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return _context.Decks.Find(id);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return _context.Decks.Where(d => !d.IsDeleted);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            _context.Decks.Update(entity as DecksDataEntity);
            _context.SaveChanges();
        }
    }
}
