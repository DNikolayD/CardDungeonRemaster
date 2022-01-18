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
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<string> entity)
        {
            this._context.Users.Add(entity as ApplicationUser);
            this._context.SaveChanges();
        }

        public void Delete(string id)
        {
            ApplicationUser applicationUser = this._context.Users.FirstOrDefault(x => x.Id == id);
            applicationUser.IsDeleted = true;
            applicationUser.DeletedOn = DateTime.Now;
            this.Update(applicationUser);
        }

        public IEnumerable<IBaseDataEntity<string>> GetAll()
        {
            return this._context.Users.Where(x => !x.IsDeleted);
        }

        public IBaseDataEntity<string> GetById(string id)
        {
            return this._context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(IBaseDataEntity<string> entity)
        {
            entity.IsEdited = true;
            entity.EditedOn = DateTime.Now;
            this._context.Users.Update(entity as ApplicationUser);
            this._context.SaveChanges();
        }
    }
}
