using Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.DeckTypesConstraints;

namespace Data.Entities
{
    public class DeckTypesDataEntity : BaseDataEntity<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
    }
}
