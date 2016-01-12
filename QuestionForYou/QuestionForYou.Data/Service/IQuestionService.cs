using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Service
{
    public interface IQuestionService
    {

        Question CreateQuestion(Question question);

        Question GetQuestionById(int id);

        List<Question> GetQuestionsForCategory(Category category);

        Question GetRandomQuestionForUser();

    }
}
