using Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.EffectsConstraints;

namespace Data.Entities
{
    public class EffectsDataEntity : BaseDataEntity<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Description { get; init; }

        [Required]
        public int TypeId { get; init; }

        public EffectTypesDataEntity EffectType { get; init; }

        public int? Value { get; init; }

        public int? ActiveTurns { get; init; }
    }
}
