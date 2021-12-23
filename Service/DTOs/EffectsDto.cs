using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class EffectsDto : BaseDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public EffectTypesDto EffectType { get; set; }

        public int? Value { get; set; }

        public int? ActiveTurns { get; set; }
    }
}
