using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Service
{
    internal interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> CreateCategoriesAsync(Category category);
    }
}