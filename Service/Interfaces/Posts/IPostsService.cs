using Service.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Posts
{
    public interface IPostsService
    {
        public IEnumerable<PostsDto> GetAllPosts();

        public PostsDto GetPostById(string id);

        public void Create(PostsDto postsDto);

        public void Update(PostsDto postsDto);

        public void Delete(string id);

        public IEnumerable<PostsDto> GetAscendingByLikes();

        public IEnumerable<PostsDto> GetDescendingByLikes();

        public IEnumerable<PostsDto> GetAscendingByDislikes();

        public IEnumerable<PostsDto> GetDescendingByDislikes();

        public IEnumerable<PostsDto> GetPostsByTitle(string title);

        public IEnumerable<PostsDto> GetPostsByTitleAscending();

        public IEnumerable<PostsDto> GetPostsByTitleDescending();

        public IEnumerable<PostsDto> GetPostsByDate(DateTime date);

        public IEnumerable<PostsDto> GetPostsByDateAscending();

        public IEnumerable<PostsDto> GetPostsByDateDescending();

        public IEnumerable<PostsDto> GetPostsByCreator(string name);
    }
}
