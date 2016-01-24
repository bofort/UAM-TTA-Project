using FakeItEasy;
using NUnit.Framework;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;
using System.Collections.Generic;

namespace QuestionForYou.Tests.Unit.Service
{
    [TestFixture]
    public class AnswerServiceTests
    {
        private AnswerService _sut;
        private IRepository<Answer> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Answer>>();
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

        [Test]
        public void GetAnswersForQuestion_Should_Return_Aswers_For_Question()
        {
            List<Answer> answers = new List<Answer>
            {
                new Answer {Id = 1, Text = "a", QuestionId = 12},
                new Answer {Id = 2, Text = "b", QuestionId = 12},
                new Answer {Id = 13, Text = "c", QuestionId = 12},
                new Answer {Id = 14, Text = "d", QuestionId = 12},
                 new Answer {Id = 14, Text = "d", QuestionId = 13}
            };

            A.CallTo(() => _repository.GetAll()).Returns(answers);

            List<Answer> answersList = _sut.GetAnswersForQuestion(12);

            Assert.True(answersList.TrueForAll(x => x.QuestionId == 12));
        }
    }
}