using Data.Entities.Common;
using Data.Entities.Forum;
using Data.Entities.User;
using Data.Entities;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DTOs.Posts;

namespace Service.DTOs.User
{
    public class UserDto : BaseDto<string>
    {
        public string DisplayName { get; set; }

        public ImagesDto ProfilePhoto { get; set; }

        public RoleDto Role { get; set; }

        public virtual IEnumerable<CardsDto> CreatedCards { get; set; }

        public virtual IEnumerable<DecksDto> CreatedDecks { get; set; }

        public virtual IEnumerable<PostsDto> CreatedPosts { get; set; }

        public virtual IEnumerable<CommentsDto> CreatedComments { get; set; }

        public virtual IEnumerable<PostsDto> LikedPosts { get; set; }

        public virtual IEnumerable<CommentsDto> LikedComments { get; set; }

        public virtual IEnumerable<PostsDto> DislikedPosts { get; set; }

        public virtual IEnumerable<CommentsDto> DislikedComments { get; set; }
    }
}
