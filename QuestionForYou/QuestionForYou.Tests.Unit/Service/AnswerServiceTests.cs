using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using NUnit.Framework;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Tests.Unit.Service
{
    [TestFixture]
    public class AnswerServiceTests
    {

        private AnswerService _sut;
        private IRepository<Answer> _repository;
        private IRepository<Question> _questionRepository;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Answer>>();
            _questionRepository = A.Fake<IRepository<Question>>();
            _sut = new AnswerService(_repository);
        }

        [Test]
        public void CreateAnswer_Should_Persist_Question_In_Repository()
        {
            var answer = new Answer();

            _sut.CreateAnswer(answer);

            A.CallTo(() => _repository.Persist(answer)).MustHaveHappened();

        }

        [Test]
        public void CreateAnswer_Should_Return_Question()
        {
            var answer = new Answer();

            Answer newAnswer = _sut.CreateAnswer(answer);

            A.Equals(answer, newAnswer);
        }

        [Test]
        public void GetAnswersForQuestion_Should_Return_Question_For_Repository()
        {
            _sut.GetAnswersForQuestion(1);

            A.CallTo(() => _repository.GetAll()).MustHaveHappened();
        }

        [Ignore]
        [Test]
        public void GetAnswersForQuestion_Should_Return_Aswers_For_Question()
        {
            var q1 = new Question
            {
                Id = 12
            };

            List<Answer> answers = new List<Answer>
            {
                new Answer {Id = 1, Text = "a", },
                new Answer {Id = 1, Text = "b", },
                new Answer {Id = 1, Text = "c", },
                new Answer {Id = 1, Text = "d", }
            };

            A.CallTo(() => _repository.GetAll()).Returns(answers);

            List<Answer> answersList = _sut.GetAnswersForQuestion(12);

            Assert.True(answersList.TrueForAll(x=>x.Id==1));
        }

    }
}
