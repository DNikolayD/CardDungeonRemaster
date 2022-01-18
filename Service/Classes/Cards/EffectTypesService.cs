using AutoMapper;
using Data.Entities;
using Data.Repositories.Classes.Cards;
using Data.Repositories.Intrefaces.Cards;
using Service.Common;
using Service.DTOs;
using Service.Interfaces.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Classes
{
    public class EffectTypesService : IEffectTypesService
    {

        private readonly IEffectTypesRepository _repository;
        private readonly IMapper _mapper;

        public EffectTypesService(EffectTypesRepository repository,
                                  Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(EffectTypesDto effectType)
        {
            this._repository.Create(this._mapper.Map<EffectTypesDataEntity>(effectType));
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<EffectTypesDto> GetAllEffectTypes()
        {
            return this._repository.GetAll().Select(e => e as EffectTypesDataEntity).Select(e => this._mapper.Map<EffectTypesDto>(e));
        }

        public EffectTypesDto GetEffectTypeById(int id)
        {
            return this.GetAllEffectTypes().FirstOrDefault(e => e.Id == id);
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
            this._repository.Update(this._mapper.Map<EffectTypesDataEntity>(effectType));
        }
    }
}
