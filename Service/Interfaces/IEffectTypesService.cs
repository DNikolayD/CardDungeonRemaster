using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IEffectTypesService
    {
        public IEnumerable<EffectTypesDto> GetAllEffectTypes();

        public void Delete(int id);

        public EffectTypesDto GetEffectTypeById(int id);

        public IEnumerable<EffectTypesDto> GetEffectTypesOrderdByNameDessending();

        public IEnumerable<EffectTypesDto> GetEffextTypesOrderdByNameAssending();

        public IEnumerable<EffectTypesDto> GetEffectTypesWithTheName(string name);

        public void Create(EffectTypesDto effectType);

        public void Update(EffectTypesDto effectType);
    }
}
