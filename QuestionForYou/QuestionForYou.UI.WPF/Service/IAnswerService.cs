using System.Collections.Generic;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.UI.WPF.Service
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAnswersForQuestionAsync(int id);
        Task<Answer> CreateAnswerAsync(Answer answer);
    }
}