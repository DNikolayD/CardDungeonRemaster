using Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CardTypesConstraints;

namespace Service.DTOs
{
    public class CardTypesDto : BaseDto<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }
    }
}
