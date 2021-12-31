using Data.Entities.Common;
using Data.Repositories.Intrefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes
{
    public class ImagesRepository : IImagesRepository
    {

        private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Images.Add(entity as ImagesDataEntity);
        }

        public void Delete(string id)
        {
            ImagesDataEntity entity = this._context.Images.Find(id);
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
            this.Update(entity);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Images.Where(x => !x.IsDeleted);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Images.Find(id);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Images.Update(entity as ImagesDataEntity);
            this._context.SaveChanges();
        }
    }
}
