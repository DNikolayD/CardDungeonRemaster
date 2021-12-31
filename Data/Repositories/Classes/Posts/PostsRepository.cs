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
    public class PostsRepository : IPostsRepository
    {

        private readonly ApplicationDbContext _context;

        public PostsRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Posts.Add(entity as PostsDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            PostsDataEntity entity = this._context.Posts.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Posts.Where(p => !p.IsDeleted);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Posts.Find(id);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Posts.Update(entity as PostsDataEntity);
            this._context.SaveChanges();
        }
    }
}
