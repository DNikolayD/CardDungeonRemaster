﻿using Data.Common;
using Data.Entities;
using Data.Repositories.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories.Classes
{
    public class DecksRepository : IDecksRepository
    {

        private readonly ApplicationDbContext _context;

        public DecksRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Decks.Add(entity as DecksDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            DecksDataEntity deck = this.GetById(id) as DecksDataEntity;
            deck.IsDeleted = true;
            deck.DeletedOn = DateTime.Now;
            this.Update(deck);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Decks.Find(id);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Decks.Where(d => !d.IsDeleted);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Decks.Update(entity as DecksDataEntity);
            this._context.SaveChanges();
        }
    }
}
