using Data.Entities;
using Data.Repositories.Classes;
using Data.Repositories.Intrefaces;
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
    public class EffectsService : IEffectsService
    {

        private readonly IEffectsRepository _repository;

        public EffectsService(EffectsRepository repository)
        {
            this._repository = repository;
        }

        public void Create(EffectsDto effect)
        {
            this._repository.Create(effect.GetEffectsDataEntity());
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<EffectsDto> GetAllEffects()
        {
            return this._repository.GetAll().Select(e => e as EffectsDataEntity).Select(e => e.GetEffectsDto());
        }

        public EffectsDto GetEffectById(int id)
        {
            return (_repository.GetById(id) as EffectsDataEntity).GetEffectsDto();
        }

        public IEnumerable<EffectsDto> GetEffectsOrderdByNameAssending()
        {
            return this.GetEffectsOrderdByNameDessending().Reverse();
        }

        public IEnumerable<EffectsDto> GetEffectsOrderdByNameDessending()
        {
            return this.GetAllEffects().OrderByDescending(e => e.Name);
        }

        public IEnumerable<EffectsDto> GetEffectsWithActiveTurns()
        {
            return this.GetAllEffects().Where(e => e.ActiveTurns != null);
        }

        public IEnumerable<EffectsDto> GetEffectsWithActiveTurnsOf(int activeTurns)
        {
            return this.GetAllEffects().Where(e => e.ActiveTurns == activeTurns);
        }

        public IEnumerable<EffectsDto> GetEffectsWithEffectType(EffectTypesDto effectTypesDto)
        {
            return this.GetAllEffects().Where(e => e.EffectType == effectTypesDto);
        }

        public IEnumerable<EffectsDto> GetEffectsWithNoActiveTurns()
        {
            return this.GetAllEffects().Where(e => e.ActiveTurns == null);
        }

        public IEnumerable<EffectsDto> GetEffectsWithNoValue()
        {
            return this.GetAllEffects().Where(e => e.Value == null);
        }

        public IEnumerable<EffectsDto> GetEffectsWithTheName(string name)
        {
            return this.GetAllEffects().Where(e => e.Name == name);
        }

        public IEnumerable<EffectsDto> GetEffectsWithValueOf(int value)
        {
            return this.GetAllEffects().Where(e => e.Value == value);
        }

        public IEnumerable<EffectsDto> GetEffectsWithValues()
        {
            return this.GetAllEffects().Where(e => e.Value != null);
        }

        public void Update(EffectsDto effect)
        {
            this._repository.Update(effect.GetEffectsDataEntity());
        }
    }
}
