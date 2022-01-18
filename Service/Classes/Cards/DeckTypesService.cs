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
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes
{
    public class DeckTypesService : IDeckTypesService
    {

        private readonly IDeckTypesRepository _repository;
        private readonly IMapper _mapper;

        public DeckTypesService(DeckTypesRepository repository)
        {
            this._repository = repository;
        }

        public void Create(DeckTypesDto deckType)
        {
            this._repository.Create(this._mapper.Map<DeckTypesDataEntity>(deckType));
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<DeckTypesDto> GetAllDeckTypes()
        {
            return this._repository.GetAll().Select(d => d as DeckTypesDataEntity).Select(d => this._mapper.Map<DeckTypesDto>(d));
        }

        public DeckTypesDto GetDeckTypeById(int id)
        {
            return this.GetAllDeckTypes().FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<DeckTypesDto> GetDeckTypesOrderdByNameAssending()
        {
            return this.GetAllDeckTypes().OrderBy(d => d.Name);
        }

        public IEnumerable<DeckTypesDto> GetDeckTypesOrderdByNameDessending()
        {
            return this.GetAllDeckTypes().OrderByDescending(d => d.Name);
        }

        public IEnumerable<DeckTypesDto> GetDeckTypesWithTheName(string name)
        {
            return this.GetAllDeckTypes().Where(d => d.Name == name);
        }

        public void Update(DeckTypesDto deckType)
        {
            this._repository.Update(this._mapper.Map<DeckTypesDataEntity>(deckType));
        }
    }
}
