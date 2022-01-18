using AutoMapper;
using Data.Entities.Forum;
using Data.Repositories.Classes.Posts;
using Data.Repositories.Intrefaces.Posts;
using Service.DTOs.Posts;
using Service.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes.Posts
{
    public class PostsService : IPostsService
    {

        private readonly IPostsRepository _repository;
        private readonly IMapper _mapper;

        public PostsService(PostsRepository repository,
                            Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(PostsDto postsDto)
        {
            this._repository.Create(this._mapper.Map<PostsDataEntity>(postsDto));
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<PostsDto> GetAllPosts()
        {
            return this._repository.GetAll().Select(p => p as PostsDataEntity).Select(p => this._mapper.Map<PostsDto>(p));
        }

        public IEnumerable<PostsDto> GetAscendingByDislikes()
        {
            return this.GetAllPosts().OrderBy(p => p.Dislikes);
        }

        public IEnumerable<PostsDto> GetAscendingByLikes()
        {
            return this.GetAllPosts().OrderBy(p => p.Likes);
        }

        public IEnumerable<PostsDto> GetDescendingByDislikes()
        {
            return this.GetAllPosts().OrderByDescending(p => p.Dislikes);
        }

        public IEnumerable<PostsDto> GetDescendingByLikes()
        {
            return this.GetAllPosts().OrderByDescending(p => p.Likes);
        }

        public PostsDto GetPostById(string id)
        {
            return this.GetAllPosts().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<PostsDto> GetPostsByCreator(string name)
        {
            return this.GetAllPosts().Where(p => p.Creator.DisplayName == name);
        }

        public IEnumerable<PostsDto> GetPostsByDate(DateTime date)
        {
            return this.GetAllPosts().Where(p => p.CreatedOn == date);
        }

        public IEnumerable<PostsDto> GetPostsByDateAscending()
        {
            return this.GetAllPosts().OrderBy(p => p.CreatedOn);
        }

        public IEnumerable<PostsDto> GetPostsByDateDescending()
        {
            return this.GetAllPosts().OrderByDescending(p => p.CreatedOn);
        }

        public IEnumerable<PostsDto> GetPostsByTitle(string title)
        {
            return this.GetAllPosts().Where(p => p.Title == title);
        }

        public IEnumerable<PostsDto> GetPostsByTitleAscending()
        {
            return this.GetAllPosts().OrderBy(p => p.Title);
        }

        public IEnumerable<PostsDto> GetPostsByTitleDescending()
        {
            return this.GetAllPosts().OrderByDescending(p => p.Title);
        }

        public void Update(PostsDto postsDto)
        {
            this._repository.Update(this._mapper.Map<PostsDataEntity>(postsDto));
        }
    }
}
