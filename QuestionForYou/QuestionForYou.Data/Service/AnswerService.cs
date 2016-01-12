using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Data.Service
{
    public class AnswerService
    {

        private readonly IRepository<Answer> _questionRepository;

        public AnswerService(IRepository<Answer> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Answer CreateAnswer(Answer answer)
        {
            return _questionRepository.Persist(answer);
        }

        public List<Answer> GetAnswers()
        {
            return _questionRepository.GetAll().ToList();
        }

    }
}
