using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;
using System.Collections.Generic;
using System.Linq;

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

        public Category FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Category UpdateCategory(Category category)
        {
            return _repository.Persist(category);
        }

        public void DeleteCategory(Category category)
        {
            _repository.Remove(category);
        }

    }
}