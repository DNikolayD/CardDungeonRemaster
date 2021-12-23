using Data.Common;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class DecksDataEntity : BaseDataEntity<string>
    {
        public DecksDataEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new List<CardsDataEntity>();
        }

        public string Name { get; init; }

        public string Description { get; init; }

        public DeckTypesDataEntity DeckType { get; init; }

        public IEnumerable<CardsDataEntity> Cards { get; init; }
    }
}
