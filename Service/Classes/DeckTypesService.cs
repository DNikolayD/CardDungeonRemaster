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
    public class DeckTypesService : IDeckTypesService
    {

        private readonly IDeckTypesRepository _repository;

        public DeckTypesService(DeckTypesRepository repository)
        {
            this._repository = repository;
        }

        public void Create(DeckTypesDto deckType)
        {
            this._repository.Create(deckType.GetDeckTypesDataEntity());
        }

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<DeckTypesDto> GetAllDeckTypes()
        {
            return this._repository.GetAll().Select(d => d as DeckTypesDataEntity).Select(d => d.GetDeckTypes());
        }

        public DeckTypesDto GetDeckTypeById(int id)
        {
            return (this._repository.GetById(id) as DeckTypesDataEntity).GetDeckTypes();
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
            this._repository.Update(deckType.GetDeckTypesDataEntity());
        }
    }
}
