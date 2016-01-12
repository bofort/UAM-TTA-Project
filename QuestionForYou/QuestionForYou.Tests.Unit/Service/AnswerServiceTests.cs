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

    }
}
