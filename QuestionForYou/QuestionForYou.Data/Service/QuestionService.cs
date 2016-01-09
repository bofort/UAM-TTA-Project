using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Data.Service
{
    public class QuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly QuestionFactory _questionFactory;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
            _questionFactory = new QuestionFactory();
        }

        public Question CreateQuestion(Question question)
        {
            return _questionRepository.Persist(question);
        }

        public Question GetQuestionById(int id)
        {
            var expression = new List<Expression<Func<Question, object>>>
            {
                (x) => x.Answers,
                (x) => x.Category
            };
            return _questionRepository.FindById(id, expression.ToArray());
        }

        public List<Question> GetQuestionsForCategory(Category category)
        {
            var expression = new List<Expression<Func<Question, object>>>
            {
                (x) => x.Answers,
                (x) => x.Category
            };
            return _questionRepository.GetAll(expression.ToArray()).Where(x => x.Category == category).ToList();
        }

        public Question GetRandomQuestionForUser(User user)
        {
            return _questionFactory.PrepareQuestionForUser(_questionRepository.GetAll().OrderBy(x => Guid.NewGuid()).First());
        }
    }
}
