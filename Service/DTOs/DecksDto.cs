using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class DecksDto : BaseDto<string>
    {
        public DecksDto() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new List<CardsDto>();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DeckTypesDto DeckType { get; set; }

        public IEnumerable<CardsDto> Cards { get; set; }
    }
}
