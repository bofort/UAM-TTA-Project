using QuestionForYou.Data.Model;
using System.Collections.Generic;

namespace QuestionForYou.Data.Service
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);

        List<Category> GetAll();

        Category FindById(int id);

        Category UpdateCategory(Category category);

        void DeleteCategory(Category category);
    }
}