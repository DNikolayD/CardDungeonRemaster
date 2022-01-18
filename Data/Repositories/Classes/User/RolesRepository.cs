using Data.Entities.Common;
using Data.Entities.User;
using Data.Repositories.Intrefaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes.User
{
    public class RolesRepository : IRolesRepository
    {

        private readonly ApplicationDbContext _context;

        public RolesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Roles.Add(entity as ApplicationRole);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            ApplicationRole applicationRole = this._context.Roles.FirstOrDefault(x => x.Id == id);
            applicationRole.IsDeleted = true;
            applicationRole.DeletedOn = DateTime.Now;
            this.Update(applicationRole);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Roles.Where(x => !x.IsDeleted);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Roles.FirstOrDefault(x => x.Id == id);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Roles.Update(entity as ApplicationRole);
            this._context.SaveChanges();
        }
    }
}
