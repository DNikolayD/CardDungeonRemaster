using Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class EffectsDataEntity : BaseDataEntity<int>
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public EffectTypesDataEntity EffectType { get; init; }

        public int? Value { get; init; }

        public int? ActiveTurns { get; init; }
    }
}
