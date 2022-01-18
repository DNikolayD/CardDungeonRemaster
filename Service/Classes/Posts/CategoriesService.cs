using AutoMapper;
using Data.Entities.Forum;
using Data.Repositories.Classes.Posts;
using Data.Repositories.Intrefaces.Posts;
using Service.DTOs.Posts;
using Service.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Classes.Posts
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;

        public CategoriesService(CategoriesRepository repository,
                                 Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public void Create(CategoriesDto category)
        {
            this._repository.Create(this._mapper.Map<CategoriesDataEntity>(category));
        }

        public void Delete(string id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<CategoriesDto> GetAll()
        {
            return this._repository.GetAll().Select(c => c as CategoriesDataEntity).Select(c => this._mapper.Map<CategoriesDto>(c));
        }

        public CategoriesDto GetById(string id)
        {
            return this.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public CategoriesDto GetByName(string name)
        {
            return this.GetAll().FirstOrDefault(c => c.Name == name);
        }

        public IEnumerable<CategoriesDto> GetOrderdByNameAscending()
        {
            return this.GetAll().OrderBy(c => c.Name);
        }

        public IEnumerable<CategoriesDto> GetOrderdByNameDescending()
        {
            return this.GetAll().OrderByDescending(c => c.Name);
        }

        public IEnumerable<CategoriesDto> GetOrderdByPostsAscending()
        {
            return this.GetAll().OrderBy(c => c.Posts.Count());
        }

        public IEnumerable<CategoriesDto> GetOrderdByPostsDescending()
        {
            return this.GetAll().OrderByDescending(c => c.Posts.Count());
        }

        public void Update(CategoriesDto category)
        {
            this._repository.Update(this._mapper.Map<CategoriesDataEntity>(category));
        }
    }
}
