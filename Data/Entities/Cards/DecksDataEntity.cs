using Data.Entities.Common;
using Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DataConstraints.DecksConstraints;

namespace Data.Entities
{
    public class DecksDataEntity : BaseDataEntity<string>
    {
        public DecksDataEntity() : base()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cards = new List<CardsDataEntity>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; init; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; init; }

        [Required]
        public int TypeId { get; init; }

        public  virtual DeckTypesDataEntity DeckType { get; init; }

        [Required]
        public string CreatorId { get; init; }

        public virtual ApplicationUser Creator { get; init; }

        public virtual IEnumerable<CardsDataEntity> Cards { get; init; }

    }
}
