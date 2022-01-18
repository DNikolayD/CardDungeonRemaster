using Data.Entities.Common;
using Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataConstraints.PostsConstraints;

namespace Data.Entities.Forum
{
    public class PostsDataEntity : BaseDataEntity<string>
    {

        public PostsDataEntity() : base()
        {
            this.Images = new HashSet<ImagesDataEntity>();
            this.Comments = new HashSet<CommentsDataEntity>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public virtual IEnumerable<ImagesDataEntity> Images { get; set; }

        public virtual IEnumerable<CommentsDataEntity> Comments { get; set; }

    }
}
