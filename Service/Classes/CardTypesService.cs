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
    public class CardTypesService : ICardTypesService
    {

        private readonly ICardTypesRepository _repository;

        public CardTypesService(CardTypesRepository repository)
        {
            this._repository = repository;
        }

        public void Create(CardTypesDto cardType)
        {
            this._repository.Create(cardType.GetCardTypesDataEntity());
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<CardTypesDto> GetAllCardTypes()
        {
            return this._repository.GetAll().Select(c => c as CardTypesDataEntity).Select(c => c.GetCardTypesDto());
        }

        public CardTypesDto GetCardTypeById(int id)
        {
            return (this._repository.GetById(id) as CardTypesDataEntity).GetCardTypesDto();
        }

        public IEnumerable<CardTypesDto> GetCardTypesOrderdByNameAssending()
        {
            return this.GetCardTypesOrderdByNameDessending().Reverse();
        }

        public IEnumerable<CardTypesDto> GetCardTypesOrderdByNameDessending()
        {
            return this.GetAllCardTypes().OrderByDescending(c => c.Name);
        }

        public IEnumerable<CardTypesDto> GetCardTypesWithTheName(string name)
        {
            return this.GetAllCardTypes().Where(c => c.Name == name);
        }

        public void Update(CardTypesDto cardType)
        {
            this._repository.Update(cardType.GetCardTypesDataEntity());
        }
    }
}
