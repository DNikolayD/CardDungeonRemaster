using Service.Common;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CardsConstraints;

namespace Service.DTOs
{
    public class CardsDto : BaseDto<string>
    {

        public CardsDto() : base()
        {
            this.Image = new ImagesDto();
            this.Effects = new HashSet<EffectsDto>();
            this.CardType = new CardTypesDto();
            this.Creator = new UserDto();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        public int? Cost { get; set; }
        
        [Required]
        public virtual ImagesDto Image { get; set; }

        public virtual IEnumerable<EffectsDto> Effects { get; set; }

        [Required]
        public virtual CardTypesDto CardType { get; set; }

        [Required]
        public virtual UserDto Creator { get; set; }

    }
}
