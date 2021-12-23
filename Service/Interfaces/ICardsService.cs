using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICardsService
    {
        public IEnumerable<CardsDto> GetAllCards ();

        public void Delete(string id);

        public CardsDto GetCardById (string id);

        public IEnumerable<CardsDto> GetCardsOrderdByNameDessending();

        public IEnumerable<CardsDto> GetCardsOrderdByNameAssending();

        public IEnumerable<CardsDto> GetCardsWithValues();

        public IEnumerable<CardsDto> GetCardsWithValueOf(int value);

        public IEnumerable<CardsDto> GetCardsWithNoValue();

        public IEnumerable<CardsDto> GetCardsWithActiveTurns();

        public IEnumerable<CardsDto> GetCardsWithActiveTurnsOf(int activeTurns);

        public IEnumerable<CardsDto> GetCardsWithNoActiveTurns();

        public IEnumerable<CardsDto> GetCardsWithTheName(string name);

        public IEnumerable<CardsDto> GetCardsWithEffectType(EffectTypesDto effectTypesDto);

        public void Create(CardsDto card);

        public void Update(CardsDto card);

        public void Play(string id);
    }
}
