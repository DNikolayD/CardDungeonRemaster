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
    public class CommentsService : ICommentsService
    {

        private readonly ICommentsRepository _repository;
        private readonly IMapper _mapper;

        public CommentsService(CommentsRepository repository,
                               Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(CommentsDto commentsDto)
        {
            this._repository.Create(this._mapper.Map<CommentsDataEntity>(commentsDto));
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<CommentsDto> GetAllComments()
        {
            return this._repository.GetAll().Select(c => c as CommentsDataEntity).Select(c => this._mapper.Map<CommentsDto>(c));
        }

        public IEnumerable<CommentsDto> GetAscendingByDislikes()
        {
            return this.GetAllComments().OrderBy(c => c.Dislikes);
        }

        public IEnumerable<CommentsDto> GetAscendingByLikes()
        {
            return this.GetAllComments().OrderBy(c => c.Likes);
        }

        public IEnumerable<CommentsDto> GetCommentsByCreator(string name)
        {
            return this.GetAllComments().Where(c => c.Creator.DisplayName == name);
        }

        public IEnumerable<CommentsDto> GetCommentsByDate(DateTime date)
        {
            return this.GetAllComments().Where(c => c.CreatedOn == date);
        }

        public IEnumerable<CommentsDto> GetCommentsByDateAscending()
        {
            return this.GetAllComments().OrderBy(c => c.CreatedOn);
        }

        public IEnumerable<CommentsDto> GetCommentsByDateDescending()
        {
            return this.GetAllComments().OrderByDescending(c => c.CreatedOn);
        }

        public IEnumerable<CommentsDto> GetDescendingByDislikes()
        {
            return this.GetAllComments().OrderByDescending(c => c.Dislikes);
        }

        public IEnumerable<CommentsDto> GetDescendingByLikes()
        {
            return this.GetAllComments().OrderByDescending(c => c.Likes);
        }

        public void Update(CommentsDto commentsDto)
        {
            this._repository.Update(this._mapper.Map<CommentsDataEntity>(commentsDto));
        }
    }
}