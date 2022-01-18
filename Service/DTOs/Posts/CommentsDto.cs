using Service.Common;
using Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CommentsConstraints;

namespace Service.DTOs.Posts
{
    public class CommentsDto : BaseDto<int>
    {

        public CommentsDto()
        {

        }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public virtual IEnumerable<ImagesDto> Images { get; set; }

        [Required]
        public virtual UserDto Creator { get; set; }
    }
}
