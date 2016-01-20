using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuestionForYou.Data.Model;

namespace QuestionForYou.UI.WPF.Service
{
    internal interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoriesAsync(Category category);
    }
}