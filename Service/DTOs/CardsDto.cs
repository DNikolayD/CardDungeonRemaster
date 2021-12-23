using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class CardsDto : BaseDto<string>
    {
        public CardsDto() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Effects = new HashSet<EffectsDto>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<EffectsDto> Effects { get; set; }

        public CardTypesDto CardType { get; set; }

    }
}
