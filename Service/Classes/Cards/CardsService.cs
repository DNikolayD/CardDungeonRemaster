using AutoMapper;
using Data.Entities;
using Data.Entities.User;
using Data.Repositories.Base;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Classes.User;
using Data.Repositories.Intrefaces.Cards;
using Data.Repositories.Intrefaces.User;
using Service.Common;
using Service.DTOs;
using Service.DTOs.User;
using Service.Interfaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Service.Classes.Cards
{
    public class CardsService : ICardsService
    {

        private readonly ICardsRepository _repository;
        private readonly IMapper _mapper;


        public CardsService(CardsRepository repository,
                            Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(CardsDto card)
        {
            CardsDataEntity cardsDataEntity = this._mapper.Map<CardsDataEntity>(card);
            this._repository.Create(cardsDataEntity);
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<CardsDto> GetAllCards()
        {
            IEnumerable<CardsDataEntity> cardsDataEntities = this._repository.GetAll().Select(c => c as CardsDataEntity);
            return cardsDataEntities.Select(c => this._mapper.Map<CardsDto>(c));
        }

        public CardsDto GetCardById(string id)
        {
            return this.GetAllCards().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CardsDto> GetCardsOrderdByNameAssending()
        {
            return this.GetCardsOrderdByNameDessending().Reverse();
        }

        public IEnumerable<CardsDto> GetCardsOrderdByNameDessending()
        {
            return this.GetAllCards().OrderByDescending(c => c.Name);
        }

        public IEnumerable<CardsDto> GetCardsWithEffectType(EffectTypesDto effectTypesDto)
        {
            return this.GetAllCards().Where(c => c.Effects.Where(e => e.EffectType == effectTypesDto).Any());
        }

        public IEnumerable<CardsDto> GetCardsWithValues()
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.Value != null));
        }

        public void Play(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(CardsDto card)
        {
            this._repository.Update(this._mapper.Map<CardsDataEntity>(card));
        }

        public IEnumerable<CardsDto> GetCardsWithValueOf(int value)
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.Value == value));
        }

        public IEnumerable<CardsDto> GetCardsWithNoValue()
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.Value == null));
        }

        public IEnumerable<CardsDto> GetCardsWithTheName(string name)
        {
            return GetAllCards().Where(c => c.Name == name);
        }

        public IEnumerable<CardsDto> GetCardsWithActiveTurns()
        {
            return GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns != null));
        }

        public IEnumerable<CardsDto> GetCardsWithActiveTurnsOf(int activeTurns)
        {
            return GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns == activeTurns));
        }

        public IEnumerable<CardsDto> GetCardsWithNoActiveTurns()
        {
            return GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns == null));
        }

        public IEnumerable<CardsDto> GetCardsByDate(DateTime date)
        {
            return this.GetAllCards().Where(x => x.CreatedOn == date);
        }

        public IEnumerable<CardsDto> GetCardsDescendingByDate()
        {
            return this.GetAllCards().OrderByDescending(x => x.CreatedOn);
        }

        public IEnumerable<CardsDto> GetCardsAscendingByDate()
        {
            return this.GetAllCards().OrderBy(x => x.CreatedOn);
        }
    }
}
