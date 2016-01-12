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
    public class QuestionService : IQuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private readonly QuestionFactory _questionFactory;
        private readonly List<Expression<Func<Question, object>>> _expression;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
            _questionFactory = new QuestionFactory();
            _expression = new List<Expression<Func<Question, object>>>
            {
                (x) => x.Answers,
                (x) => x.Category
            };
        }

        public Question CreateQuestion(Question question)
        {
            return _questionRepository.Persist(question);
        }

        public Question GetQuestionById(int id)
        {
            return _questionRepository.FindById(id, _expression.ToArray());
        }

        public List<Question> GetQuestionsForCategory(Category category)
        {
            return _questionRepository.GetAll(_expression.ToArray()).Where(x => x.Category == category).ToList();
        }

        public Question GetRandomQuestionForUser()
        {
            List<Question> list = _questionRepository.GetAll(_expression.ToArray()).ToList();
            if (list.Count > 0)
            {
                Question q = list.OrderBy(x => Guid.NewGuid()).First();
                return _questionFactory.PrepareQuestionForUser(q);
            }
            return null;
        }
    }
}
