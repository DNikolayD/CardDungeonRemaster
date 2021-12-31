using Data.Entities.Common;
using Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.CommentsConstraints;

namespace Data.Entities.Forum
{
    public class CommentsDataEntity : BaseDataEntity<int>
    {

        public CommentsDataEntity()
        {
            this.Images = new HashSet<ImagesDataEntity>();
        }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual IEnumerable<ImagesDataEntity> Images { get; set; }
    }
}
