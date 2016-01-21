using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


using QuestionForYou.UI.WPF.Contracts;

namespace QuestionForYou.UI.WPF.Service
{
    public class QuestionService : ServiceBase, IQuestionService
    {

        public async Task<Question> GetRandomQuestionAsync()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/questions");
                var question = await response.Content.ReadAsAsync<Question>();
                return question;
            }
        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/questions/"+id);
                var question = await response.Content.ReadAsAsync<Question>();
                return question;
            }
        }

        public async Task<Question> CreateCategoriesAsync(Question question)
        {
            using (var client = CreateClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(question));
                HttpResponseMessage response = await client.PostAsync("api/questions", httpContent);
                var newQuestion = await response.Content.ReadAsAsync<Question>();
                return newQuestion;
            }
        }

    }
}
