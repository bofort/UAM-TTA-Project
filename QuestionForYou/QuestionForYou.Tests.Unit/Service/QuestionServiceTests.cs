using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private IQuestionFactory _questionFactory;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Question>>();
            _questionFactory = A.Fake<IQuestionFactory>();

            _sut = new QuestionService(_repository);
        }

        [Test]
        public void CreateQuestion_Should_Persist_Question_In_Repository()
        {
            var question = new Question();

            _sut.CreateQuestion(question);

            A.CallTo(()=>_repository.Persist(A<Question>._)).MustHaveHappened();

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

            var q = _sut.GetQuestionById(id);

            A.CallTo(() => _repository.FindById(A<int>._, A<Expression<Func<Question, object>>[]>._)).MustHaveHappened();
        }

        [Test]
        public void GetQuestionById_Should_Return_Question_From_Repository()
        {
            var expected = new Question();
            A.CallTo(() => _repository.FindById(A<int>._, A<Expression<Func<Question, object>>[]>._))
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

        [Ignore]
        [Test]
        public void GetRandomQuestionForUser_Should_Get_Random_Question_For_Repository()
        {
            var nonEmptyQuestionsList = new List<Question>();
            var q1 = new Question
            {
                Id = 12,
                Category = new Category(),
                Text = "",
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            };
            var q2 = new Question
            {
                Answers = new List<Answer>
                {
                    new Answer(),
                    new Answer(),
                    new Answer(),
                    new Answer()
                }
            };
            nonEmptyQuestionsList.AddRange(new [] {q1,q2});

            A.CallTo(() => _repository.GetAll(A<Expression<Func<Question, object>>[]>._)).Returns(nonEmptyQuestionsList);

            _sut.GetRandomQuestionForUser();

            A.CallTo(() => _questionFactory.PrepareQuestionForUser(A<Question>.That.Matches(x => x == q1 || x == q2))).MustHaveHappened();
        }

        [Test]
        public void GetRandomQuestionForUser_Should_Return_Null_If_QuestionList_Is_Empty()
        {
            var emptyQuestionsList = new List<Question>();

            A.CallTo(() => _repository.GetAll(A<Expression<Func<Question, object>>[]>._)).Returns(emptyQuestionsList);

            var question = _sut.GetRandomQuestionForUser();

            Assert.That(question,Is.EqualTo(null));
        }

    }
}
