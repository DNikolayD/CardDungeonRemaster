using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Cards
{
    public interface IDecksService
    {
        public IEnumerable<DecksDto> GetAllDecks();

        public void Delete(string id);

        public DecksDto GetDeckById(string id);

        public IEnumerable<DecksDto> GetDecksOrderdByNameDessending();

        public IEnumerable<DecksDto> GetDecksOrderdByCardsCountDecsending();

        public IEnumerable<DecksDto> GetDecksOrderdByCardsCountAcsending();

        public IEnumerable<DecksDto> GetDecksWithACard(CardsDto card);

        public IEnumerable<DecksDto> GetDecksWithType(DeckTypesDto deckType);

        public IEnumerable<DecksDto> GetDecksOrderdByNameAssending();

        public IEnumerable<DecksDto> GetDecksWithTheName(string name);

        public IEnumerable<DecksDto> GetDecksByDate(DateTime date);

        public IEnumerable<DecksDto> GetDecksAscendingByDate();

        public IEnumerable<DecksDto> GetDecksDescendingByDate();

        public void Create(DecksDto deck);

        public void Update(DecksDto deck);
    }
}
