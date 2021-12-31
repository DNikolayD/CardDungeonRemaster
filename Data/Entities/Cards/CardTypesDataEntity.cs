using Data.Entities.Common;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.CardTypesConstraints;

namespace Data.Entities
{
    public class CardTypesDataEntity : BaseDataEntity<int>
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }
    }
}
