using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;
using System.Collections.Generic;
using System.Linq;

namespace QuestionForYou.Data.Service
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepository<Answer> _answerRepository;

        public AnswerService(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Answer CreateAnswer(Answer answer)
        {
            return _answerRepository.Persist(answer);
        }

        public List<Answer> GetAnswersForQuestion(int questionId)
        {
            List<Answer> answersList = _answerRepository.GetAll().ToList();
            return answersList.Where(x => x.QuestionId == questionId).ToList();
        }
    }
}