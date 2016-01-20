using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuestionForYou.Data.Model;

namespace QuestionForYou.UI.WPF.Service
{
    internal interface IQuestionService
    {
        Task<Question> GetRandomQuestionAsync();
        Task<Question> GetQuestionAsync(int id);
        Task<Question> CreateCategoriesAsync(Question question);
    }
}