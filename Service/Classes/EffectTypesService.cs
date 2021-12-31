using Data.Entities;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Intrefaces.Cards;
using Service.Common;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class EffectTypesService : IEffectTypesService
    {

        private readonly IEffectTypesRepository _repository;

        public EffectTypesService(EffectTypesRepository repository)
        {
            this._repository = repository;
        }

        public void Create(EffectTypesDto effectType)
        {
            this._repository.Create(effectType.GetEffectTypesDataEntity());
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<EffectTypesDto> GetAllEffectTypes()
        {
            return this._repository.GetAll().Select(e => e as EffectTypesDataEntity).Select(e => e.GetEffectTypesDto());
        }

        public EffectTypesDto GetEffectTypeById(int id)
        {
            return (this._repository.GetById(id) as EffectTypesDataEntity).GetEffectTypesDto();
        }

        public IEnumerable<EffectTypesDto> GetEffectTypesOrderdByNameDessending()
        {
            return this.GetAllEffectTypes().OrderByDescending(e => e.Name);
        }

        public IEnumerable<EffectTypesDto> GetEffectTypesWithTheName(string name)
        {
            return this.GetAllEffectTypes().Where(e => e.Name == name);
        }

        public IEnumerable<EffectTypesDto> GetEffextTypesOrderdByNameAssending()
        {
            return this.GetEffectTypesOrderdByNameDessending().Reverse();
        }

        public void Update(EffectTypesDto effectType)
        {
            this._repository.Update(effectType.GetEffectTypesDataEntity());
        }
    }
}
