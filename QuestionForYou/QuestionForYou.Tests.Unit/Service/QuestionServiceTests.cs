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
    public partial class QuestionServiceTests
    {

        private QuestionService _sut;
        private IRepository<Question> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Question>>();
            _sut = new QuestionService(_repository);
        }

        [Test]
        public void CreateQuestion_Should_Persist_Question_In_Repository()
        {
            var question = new Question();

            _sut.CreateQuestion(question);

            A.CallTo(()=>_repository.Persist(question)).MustHaveHappened();

        }

        [Test]
        public void CreateQuestion_Should_Return_Question()
        {
            var question = new Question();

            Question newQuestion = _sut.CreateQuestion(question);

            A.Equals(question, newQuestion);
        }

        [Test]
        public void GetQuestionById_Should_Get_Question_From_Repository()
        {
            int id = 11;

            _sut.GetQuestionById(id);

            A.CallTo(() => _repository.FindById(id)).MustHaveHappened();
        }

        [Test]
        public void GetQuestionById_Should_Return_Question_From_Repository()
        {
            var expected = new Question();
            A.CallTo(() => _repository.FindById(A<int>._))
                .Returns(expected);

            var result = _sut.GetQuestionById(11);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetQuestionsForCategory_Should_Get_Questions_For_Category_From_Repository()
        {
            Category category = new Category();

            List<Question> questions = _sut.GetQuestionsForCategory(category);

            List<Question> questionsCategory = questions.FindAll(q => q.Category == category);

            Assert.That(questions.Count,Is.EqualTo(questionsCategory.Count));
        }

    }
}
