using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Data.Service
{
    public class QuestionService
    {
        private readonly IRepository<Question> _questionRepository;
        private QuestionFactory _questionFactory;

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
            return _questionRepository.FindById(id);
        }

        public List<Question> GetQuestionsForCategory(Category category)
        {
            return _questionRepository.GetAll().Where(q => q.Category == category).ToList();
        }
    }
}
