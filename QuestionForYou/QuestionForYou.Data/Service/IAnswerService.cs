using QuestionForYou.Data.Model;
using System.Collections.Generic;

namespace QuestionForYou.Data.Service
{
    public interface IAnswerService
    {
        Answer CreateAnswer(Answer answer);

        List<Answer> GetAnswersForQuestion(int questionId);
    }
}