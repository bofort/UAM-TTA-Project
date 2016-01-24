using QuestionForYou.Data.Model;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Service
{
    public interface IQuestionService
    {
        Task<Question> GetRandomQuestionAsync();

        Task<Question> GetQuestionAsync(int id);

        Task<Question> CreateCategoriesAsync(Question question);
    }
}