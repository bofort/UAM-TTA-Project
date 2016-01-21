using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuestionForYou.UI.WPF.Contracts;


namespace QuestionForYou.UI.WPF.Service
{
    public interface IQuestionService
    {
        Task<Question> GetRandomQuestionAsync();
        Task<Question> GetQuestionAsync(int id);
        Task<Question> CreateCategoriesAsync(Question question);
    }
}