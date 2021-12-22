using Data.Common;
using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class CardsDataEntity : BaseDataEntity<string>
    {
        public CardsDataEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Effects = new HashSet<EffectsDataEntity>();
        }

        public string Name { get; init; }

        public string Description { get; init; }

        public CardTypesDataEntity Type { get; init; }

        public IEnumerable<EffectsDataEntity> Effects { get; init; }

    }
}
