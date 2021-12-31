using Data.Entities;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Intrefaces.Cards;
using Service.Common;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class DecksService : IDecksService
    {

        private readonly IDecksRepository _repository;

        public DecksService(DecksRepository repository)
        {
            this._repository = repository;
        }

        public void Create(DecksDto deck)
        {
            this._repository.Create(deck.GetDecksDataEntity());
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<DecksDto> GetAllDecks()
        {
            return this._repository.GetAll().Select(d => d as DecksDataEntity).Select(d => d.GetDecksDto());
        }

        public DecksDto GetDeckById(string id)
        {
            return (this._repository.GetById(id) as DecksDataEntity).GetDecksDto();
        }

        public IEnumerable<DecksDto> GetDecksOrderdByCardsCountAcsending()
        {
            return this.GetDecksOrderdByCardsCountDecsending().Reverse();
        }

        public IEnumerable<DecksDto> GetDecksOrderdByCardsCountDecsending()
        {
            return this.GetAllDecks().OrderByDescending(d => d.Cards.Count());
        }

        public IEnumerable<DecksDto> GetDecksOrderdByNameAssending()
        {
            return this.GetAllDecks().OrderBy(d => d.Name);
        }

        public IEnumerable<DecksDto> GetDecksOrderdByNameDessending()
        {
            return this.GetDecksOrderdByNameAssending().Reverse();
        }

        public IEnumerable<DecksDto> GetDecksWithACard(CardsDto card)
        {
            return this.GetAllDecks().Where(d => d.Cards.Contains(card));
        }

        public IEnumerable<DecksDto> GetDecksWithTheName(string name)
        {
            return this.GetAllDecks().Where(d => d.Name == name);
        }

        public IEnumerable<DecksDto> GetDecksWithType(DeckTypesDto deckType)
        {
            return this.GetAllDecks().Where(d => d.DeckType == deckType);
        }

        public void Update(DecksDto deck)
        {
            this._repository.Update(deck.GetDecksDataEntity());
        }
    }
}
