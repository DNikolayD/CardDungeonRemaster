using Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.DeckTypesConstraints;

namespace Service.DTOs
{
    public class DeckTypesDto : BaseDto<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }
    }
}
