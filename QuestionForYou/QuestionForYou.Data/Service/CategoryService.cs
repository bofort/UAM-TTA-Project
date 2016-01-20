using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Data.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public Category CreateCategory(Category category)
        {
            return _repository.Persist(category);
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}
