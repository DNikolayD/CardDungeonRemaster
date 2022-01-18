using Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.EffectsConstraints;

namespace Service.DTOs
{
    public class EffectsDto : BaseDto<int>
    {

        public EffectsDto(): base()
        {
            this.EffectType = new EffectTypesDto();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public EffectTypesDto EffectType { get; set; }

        public int? Value { get; set; }

        public int? ActiveTurns { get; set; }
    }
}
