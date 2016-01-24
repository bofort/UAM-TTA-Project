using FakeItEasy;
using NUnit.Framework;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Tests.Unit.Service
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private CategoryService _sut;
        private IRepository<Category> _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IRepository<Category>>();
            _sut = new CategoryService(_repository);
        }

        [Test]
        public void CreateCategory_Should_Persist_Question_In_Repository()
        {
            var category = new Category();

            _sut.CreateCategory(category);

            A.CallTo(() => _repository.Persist(category)).MustHaveHappened();
        }

        [Test]
        public void CreateCategory_Should_Return_Question()
        {
            var category = new Category();

            Category newCategory = _sut.CreateCategory(category);

            A.Equals(category, newCategory);
        }

        [Test]
        public void GetAllCategories_Should_GetAll_Category_From_Repository()
        {
            _sut.GetAll();

            A.CallTo(() => _repository.GetAll()).MustHaveHappened();
        }
    }
}