using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Service
{
    public interface IQuestionFactory
    {
        Question PrepareQuestionForUser(Question question);
    }
}