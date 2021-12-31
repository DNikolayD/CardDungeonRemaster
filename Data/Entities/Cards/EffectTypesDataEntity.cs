using Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.EffectTypesConstraints;

namespace Data.Entities
{
    public class EffectTypesDataEntity : BaseDataEntity<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
    }
}
