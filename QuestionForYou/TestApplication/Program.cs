using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<QuestionForYouContext> dbContextFactory = () => new QuestionForYouContext("QuestionForYouConnectionString");
            Database.SetInitializer(new DropCreateDatabaseAlways<QuestionForYouContext>());
            dbContextFactory().Database.Initialize(true);

            QuestionService service = new QuestionService(new Repository<Question>(dbContextFactory));
            AnswerService serviceA = new AnswerService(new Repository<Answer>(dbContextFactory));
            Question question = new Question
            {
                Category = new Category(),
                Text = "dasdaasdasdasdasdsadassadsa",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                         IsCorrect = true,
                         Text = "dsdsa"
                    },
                    new Answer{
                         IsCorrect = false,
                         Text = "ddssa"
                    },
                    new Answer{
                         IsCorrect = false,
                         Text = "dsaa"
                    },new Answer{
                         IsCorrect = false,
                         Text = "dsads"
                    }
                }
            };
            var q1 = service.CreateQuestion(question);
            List<Question> q = service.GetQuestionsForCategory(new Category());

            //List<Answer> list = q.Answers.ToList();
        }
    }
}
