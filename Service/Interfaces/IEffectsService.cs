using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEffectsService
    {
        public IEnumerable<EffectsDto> GetAllEffects();

        public void Delete(int id);

        public EffectsDto GetEffectById(int id);

        public IEnumerable<EffectsDto> GetEffectsOrderdByNameDessending();

        public IEnumerable<EffectsDto> GetEffectsOrderdByNameAssending();

        public IEnumerable<EffectsDto> GetEffectsWithValues();

        public IEnumerable<EffectsDto> GetEffectsWithValueOf(int value);

        public IEnumerable<EffectsDto> GetEffectsWithNoValue();

        public IEnumerable<EffectsDto> GetEffectsWithActiveTurns();

        public IEnumerable<EffectsDto> GetEffectsWithActiveTurnsOf(int activeTurns);

        public IEnumerable<EffectsDto> GetEffectsWithNoActiveTurns();

        public IEnumerable<EffectsDto> GetEffectsWithTheName(string name);

        public IEnumerable<EffectsDto> GetEffectsWithEffectType(EffectTypesDto effectTypesDto);

        public void Create(EffectsDto effect);

        public void Update(EffectsDto effect);
    }
}
