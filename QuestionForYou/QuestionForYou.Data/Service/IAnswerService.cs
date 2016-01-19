using System.Collections.Generic;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Service
{
    public interface IAnswerService
    {
        Answer CreateAnswer(Answer answer);
        List<Answer> GetAnswersForQuestion(int questionId);
    }
}