using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Service
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAnswersForQuestionAsync(int id);

        Task<Answer> CreateAnswerAsync(Answer answer);
    }
}