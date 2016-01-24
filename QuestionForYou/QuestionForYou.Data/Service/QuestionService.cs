using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public List<Question> GetAll()
        {
            return _questionRepository.GetAll(_expression.ToArray()).ToList();
        }

        public void DeleteQuestion(Question question)
        {
            _questionRepository.Remove(question);
        }

        public Question UpdateQuestion(Question question)
        {
            Question q = _questionRepository.Persist(question);
            return _questionRepository.FindById(q.Id, _expression.ToArray());
        }

        public Question CreateQuestion(Question question)
        {
            Question q = _questionRepository.Persist(question);
            return _questionRepository.FindById(q.Id, _expression.ToArray());
        }

        public Question GetQuestionById(int id)
        {
            Question q = _questionRepository.FindById(id, _expression.ToArray());
            if (q != null)
            {
                return _questionRepository.FindById(q.Id, _expression.ToArray());
            }
            return null;
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
                Question q = list.First();
                return _questionFactory.PrepareQuestionForUser(q);
            }
            return null;
        }
    }
}