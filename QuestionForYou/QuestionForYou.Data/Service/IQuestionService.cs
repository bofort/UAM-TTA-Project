using QuestionForYou.Data.Model;
using System.Collections.Generic;

namespace QuestionForYou.Data.Service
{
    public interface IQuestionService
    {
        Question CreateQuestion(Question question);

        Question GetQuestionById(int id);

        List<Question> GetQuestionsForCategory(Category category);

        Question GetRandomQuestionForUser();

        List<Question> GetAll();

        void DeleteQuestion(Question question);

        Question UpdateQuestion(Question question);
    }
}