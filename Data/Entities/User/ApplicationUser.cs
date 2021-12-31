using Data.Entities.Common;
using Data.Entities.Forum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Data.Entities.User
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.Now;
            this.DisplayName = this.UserName;
        }

        public DateTime CreatedOn { get; init; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsEdited { get; set; }
        public DateTime EditedOn { get; set; }

        public string DisplayName { get; set; }

        public string ProfilePhotoId { get; set; }

        public ImagesDataEntity ProfilePhoto { get; set; }

        public string RoleId { get; set; }

        public ApplicationRole Role { get; set; }

        public virtual IEnumerable<CardsDataEntity> CreatedCards { get; set; }

        public virtual IEnumerable<DecksDataEntity> CreatedDecks { get; set; }

        public virtual IEnumerable<PostsDataEntity> CreatedPosts { get; set; }

        public virtual IEnumerable<CommentsDataEntity> CreatedComments { get; set; }

        public virtual IEnumerable<PostsDataEntity> LikedPosts { get; set; }

        public virtual IEnumerable<CommentsDataEntity> LikedComments { get; set; }

        public virtual IEnumerable<PostsDataEntity> DislikedPosts { get; set; }

        public virtual IEnumerable<CommentsDataEntity> DislikedComments { get; set; }
    }
}
