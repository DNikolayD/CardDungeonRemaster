using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDeckTypesService
    {
        public IEnumerable<DeckTypesDto> GetAllDeckTypes();

        public void Delete(int id);

        public DeckTypesDto GetDeckTypeById(int id);

        public IEnumerable<DeckTypesDto> GetDeckTypesOrderdByNameDessending();

        public IEnumerable<DeckTypesDto> GetDeckTypesOrderdByNameAssending();

        public IEnumerable<DeckTypesDto> GetDeckTypesWithTheName(string name);

        public void Create(DeckTypesDto deckType);

        public void Update(DeckTypesDto deckType);
    }
}
