using Data.Common;
using Data.Entities;
using Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Classes
{
    public class CardTypesRepository : IBaseRepository<int>
    {

        private readonly ApplicationDbContext _context;

        public CardTypesRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(IBaseDataEntity<int> entity)
        {
            this._context.CardTypes.Add(entity as CardTypesDataEntity);
            this._context.SaveChanges();
        }

        public void Delete(int id)
        {
            CardTypesDataEntity cardType = this.Get(id) as CardTypesDataEntity;
            cardType.IsDeleted = true;
            cardType.DeletedOn = DateTime.Now;
            this.Update(cardType);
        }

        public IBaseDataEntity<int> Get(int id)
        {
            return this._context.CardTypes.Find(id);
        }

        public IEnumerable<IBaseDataEntity<int>> GetAll()
        {
            return this._context.CardTypes.Where(x => !x.IsDeleted);
        }

        public void Update(IBaseDataEntity<int> entity)
        {
            entity.EditedOn = DateTime.Now;
            entity.IsEdited = true;
            this._context.CardTypes.Update(entity as CardTypesDataEntity);
            this._context.SaveChanges();
        }
    }
}
