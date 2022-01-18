using Service.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CategoriesConstraints;

namespace Service.DTOs.Posts
{
    public class CategoriesDto : BaseDto<string>
    {

        public CategoriesDto() : base()
        {
            this.Posts = new HashSet<PostsDto>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        public virtual IEnumerable<PostsDto> Posts { get; set; }
    }
}
