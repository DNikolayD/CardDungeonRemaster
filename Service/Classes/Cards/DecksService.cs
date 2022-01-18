using AutoMapper;
using Data.Entities;
using Data.Entities.User;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Classes.User;
using Data.Repositories.Intrefaces.Cards;
using Data.Repositories.Intrefaces.User;
using Service.Common;
using Service.DTOs;
using Service.Interfaces.Cards;
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
        private readonly IMapper _mapper;

        public DecksService(DecksRepository repository,
                            Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(DecksDto deck)
        {
            DecksDataEntity decksDataEntity = this._mapper.Map<DecksDataEntity>(deck);
            this._repository.Create(decksDataEntity);
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<DecksDto> GetAllDecks()
        {
            IEnumerable<DecksDataEntity> decksDataEntities = this._repository.GetAll().Select(d => d as DecksDataEntity);
            return decksDataEntities.Select(d => this._mapper.Map<DecksDto>(d));
        }

        public DecksDto GetDeckById(string id)
        {
            return this.GetAllDecks().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<DecksDto> GetDecksAscendingByDate()
        {
            return this.GetAllDecks().OrderBy(c => c.CreatedOn);
        }

        public IEnumerable<DecksDto> GetDecksByDate(DateTime date)
        {
            return this.GetAllDecks().Where(c => c.CreatedOn == date);
        }

        public IEnumerable<DecksDto> GetDecksDescendingByDate()
        {
            return this.GetAllDecks().OrderByDescending(c => c.CreatedOn);
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
            this._repository.Update(this._mapper.Map<DecksDataEntity>(deck));
        }
    }
}
