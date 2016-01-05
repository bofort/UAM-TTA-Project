using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Service
{
    public class QuestionFactory
    {
        public Question PrepareQuestionForUser(Question question)
        {
            List<Answer> answers = question.Answers.ToList();
            question.Answers = answers.Where(a=>!a.IsCorrect).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            question.Answers.Add(answers.FirstOrDefault(a=>a.IsCorrect));
            return question;
        }
    }

}
