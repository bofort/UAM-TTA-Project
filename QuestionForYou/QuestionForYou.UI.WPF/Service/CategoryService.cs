using Newtonsoft.Json;
using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Service
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/categories");
                var categories = await response.Content.ReadAsAsync<IEnumerable<Category>>();
                return categories;
            }
        }

        public async Task<Category> CreateCategoriesAsync(Category category)
        {
            using (var client = CreateClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(category));
                HttpResponseMessage response = await client.PostAsync("api/categories", httpContent);
                var categories = await response.Content.ReadAsAsync<Category>();
                return categories;
            }
        }
    }
}