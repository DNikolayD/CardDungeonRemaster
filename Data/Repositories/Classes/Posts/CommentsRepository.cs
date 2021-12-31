using Data.Entities.Common;
using Data.Entities.Forum;
using Data.Repositories.Intrefaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.Posts
{
    public class CommentsRepository : ICommentsRepository
    {

        private readonly ApplicationDbContext _context;

        public CommentsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            this._context.Comments.Add(entity as CommentsDataEntity);
        }

        public void Delete(int id)
        {
            CommentsDataEntity entity = this._context.Comments.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return this._context.Comments.Where(c => !c.IsDeleted);
        }

        public IBaseDataEntity<int> GetById(int id)
        {
            return this._context.Comments.Find(id);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Comments.Update(entity as CommentsDataEntity);
            this._context.SaveChanges();
        }
    }
}
