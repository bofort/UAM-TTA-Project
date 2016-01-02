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

        private IRepository<Question> _questionRepository;

        public QuestionService(IRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }



    }
}
