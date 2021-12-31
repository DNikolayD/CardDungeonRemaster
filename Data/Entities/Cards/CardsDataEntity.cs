using Data.Entities.Common;
using Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.CardsConstraints;

namespace Data.Entities
{
    public class CardsDataEntity : BaseDataEntity<string>
    {
        public CardsDataEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Effects = new HashSet<EffectsDataEntity>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Description { get; init; }

        public int Cost { get; init; }

        [Required]
        public string TypeId { get; init; }

        public virtual CardTypesDataEntity Type { get; init; }

        [Required]
        public string CreatorId { get; init; }

        public virtual ApplicationUser Creator { get; init; }

        public virtual IEnumerable<EffectsDataEntity> Effects { get; init; }

    }
}
