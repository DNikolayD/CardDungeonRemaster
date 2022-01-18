using Service.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Posts
{
    public interface ICategoriesService
    {
        public IEnumerable<CategoriesDto> GetAll();

        public CategoriesDto GetById(string id);

        public IEnumerable<CategoriesDto> GetOrderdByNameDescending();

        public IEnumerable<CategoriesDto> GetOrderdByNameAscending();

        public IEnumerable<CategoriesDto> GetOrderdByPostsDescending();

        public IEnumerable<CategoriesDto> GetOrderdByPostsAscending();

        public CategoriesDto GetByName(string name);

        public void Create(CategoriesDto category);

        public void Update(CategoriesDto category);
        
        void Delete(string id);


    }
}
