using Newtonsoft.Json;
using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Service
{
    public class AnswerService : ServiceBase, IAnswerService
    {
        public async Task<List<Answer>> GetAnswersForQuestionAsync(int id)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response = await client.GetAsync("api/questions/answers/" + id);
                var question = await response.Content.ReadAsAsync<List<Answer>>();
                return question;
            }
        }

        public async Task<Answer> CreateAnswerAsync(Answer answer)
        {
            using (var client = CreateClient())
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(answer));
                HttpResponseMessage response = await client.PostAsync("api/answers", httpContent);
                var newAnswer = await response.Content.ReadAsAsync<Answer>();
                return newAnswer;
            }
        }
    }
}