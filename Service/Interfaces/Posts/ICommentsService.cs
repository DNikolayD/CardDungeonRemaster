using Service.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Posts
{
    public interface ICommentsService
    {
        public IEnumerable<CommentsDto> GetAllComments();

        public void Create(CommentsDto commentsDto);

        public void Update(CommentsDto commentsDto);

        public void Delete(int id);

        public IEnumerable<CommentsDto> GetAscendingByLikes();

        public IEnumerable<CommentsDto> GetDescendingByLikes();

        public IEnumerable<CommentsDto> GetAscendingByDislikes();

        public IEnumerable<CommentsDto> GetDescendingByDislikes();

        public IEnumerable<CommentsDto> GetCommentsByDate(DateTime date);

        public IEnumerable<CommentsDto> GetCommentsByDateAscending();

        public IEnumerable<CommentsDto> GetCommentsByDateDescending();

        public IEnumerable<CommentsDto> GetCommentsByCreator(string name);
    }
}
