using Data.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CategoriesConstraints;

namespace Data.Entities.Forum
{
    public class CategoriesDataEntity : BaseDataEntity<string>
    {

        public CategoriesDataEntity() : base()
        {
            this.Posts = new HashSet<PostsDataEntity>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Description { get; set; }

        public virtual IEnumerable<PostsDataEntity> Posts { get; set; }
    }
}
