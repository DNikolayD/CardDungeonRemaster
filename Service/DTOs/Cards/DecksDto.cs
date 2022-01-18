using Service.Common;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.DecksConstraints;

namespace Service.DTOs
{
    public class DecksDto : BaseDto<string>
    {

        public DecksDto(): base()
        {
            this.DeckType = new DeckTypesDto();
            this.Cards = new List<CardsDto>();
            this.Creator = new UserDto();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public virtual DeckTypesDto DeckType { get; set; }

        public virtual IEnumerable<CardsDto> Cards { get; set; }

        [Required]
        public virtual UserDto Creator { get; set; }
    }
}
