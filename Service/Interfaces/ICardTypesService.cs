using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICardTypesService
    {
        public IEnumerable<CardTypesDto> GetAllCardTypes();

        public void Delete(int id);

        public CardTypesDto GetCardTypeById(int id);

        public IEnumerable<CardTypesDto> GetCardTypesOrderdByNameDessending();

        public IEnumerable<CardTypesDto> GetCardTypesOrderdByNameAssending();

        public IEnumerable<CardTypesDto> GetCardTypesWithTheName(string name);

        public void Create(CardTypesDto cardType);

        public void Update(CardTypesDto cardType);

    }
}
