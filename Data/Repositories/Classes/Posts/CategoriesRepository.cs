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
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly ApplicationDbContext _context;

        public CategoriesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Categories.Add(entity as CategoriesDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            CategoriesDataEntity category = this._context.Categories.Find(id);
            category.IsDeleted = true;
            category.DeletedOn = DateTime.Now;
            this.Update(category);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Categories.Where(c => !c.IsDeleted);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Categories.Find(id);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Categories.Update(entity as CategoriesDataEntity);
            this._context.SaveChanges();
        }
    }
}
