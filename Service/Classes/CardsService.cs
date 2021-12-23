using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Classes;
using Data.Repositories.Intrefaces;
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
    public class CardsService : ICardsService
    {

        private readonly ICardsRepository _repository;

        public CardsService(CardsRepository repository)
        {
            this._repository = repository;
        }

        public void Create(CardsDto card)
        {
            this._repository.Create(card.GetCardsDataEntity());
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<CardsDto> GetAllCards()
        {
            return this._repository.GetAll().Select(c => c as CardsDataEntity).Select(c => c.GetCardsDto());
        }

        public CardsDto GetCardById(string id)
        {
            return (this._repository.GetById(id) as CardsDataEntity).GetCardsDto();
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
            this._repository.Update(card.GetCardsDataEntity());
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
            return this.GetAllCards().Where(c => c.Name == name);
        }

        public IEnumerable<CardsDto> GetCardsWithActiveTurns()
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns != null));
        }

        public IEnumerable<CardsDto> GetCardsWithActiveTurnsOf(int activeTurns)
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns == activeTurns));
        }

        public IEnumerable<CardsDto> GetCardsWithNoActiveTurns()
        {
            return this.GetAllCards().Where(c => c.Effects.All(c => c.ActiveTurns == null));
        }
    }
}
