using NUnit.Framework;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Storage;
using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

namespace QuestionForYou.Tests.Integration.Storage
{
    [TestFixture]
    public class RepositoryTests
    {
        private static Func<QuestionForYouContext> _dbContextFactory;
        private Repository<Question> _sut;
        private TransactionScope _scope;

        [SetUp]
        public void SetUp()
        {
            _sut = new Repository<Question>(_dbContextFactory);
        }

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _dbContextFactory = () => new QuestionForYouContext("IntegrationTestsConnectionString");
            Database.SetInitializer(new DropCreateDatabaseAlways<QuestionForYouContext>());
            _dbContextFactory().Database.Initialize(true);
            _scope = new TransactionScope(TransactionScopeOption.Required);
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _scope.Dispose();
        }

        [Test]
        public void FindById_Should_Return_Null_When_Object_Og_Given_Id_Was_Not_Found()
        {
            var actual = _sut.FindById(4475438);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAll_Returns_All_Items()
        {
            var model1 = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };
            var model2 = new Question { Id = null, Text = "Wich team w", Category = new Category { Name = "Sport" } };

            _sut.Persist(model1);
            _sut.Persist(model2);
            var result = _sut.GetAll();

            Assert.That(result.Count(), Is.EqualTo(2));
            CollectionAssert.AllItemsAreUnique(result);
        }

        [Test]
        public void Persist_Should_Return_Copy_Of_Transient_Object_With_Id_Assigned()
        {
            var someTransientModel = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };

            var result = _sut.Persist(someTransientModel);

            Assert.That(result, Is.Not.Null);

            Assert.That(result, Is.Not.SameAs(someTransientModel));
            Assert.That(result.Text, Is.EqualTo(someTransientModel.Text));
            Assert.That(result.Id.HasValue);
        }

        [Test]
        public void Persisted_Data_Should_Be_Accesible_By_Id_Via_FindById()
        {
            var someTransientModel = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };

            var persisted = _sut.Persist(someTransientModel);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.Text, Is.EqualTo(persisted.Text));
            Assert.That(actual.Category, Is.EqualTo(persisted.Category));
        }

        [Test]
        public void Persisted_Object_With_Already_Existing_Id_Should_Evict_Previus_Data()
        {
            var someTransientModel = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new Question { Id = persisted.Id, Text = "Who is the tallest NBA player", Category = new Category { Name = "Sport" } };
            _sut.Persist(anotherWithSameId);
            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual.Id, Is.EqualTo(persisted.Id));
            Assert.That(actual.Text, Is.EqualTo(anotherWithSameId.Text));
        }

        [Test]
        public void Remove_Should_Remove_Item_Of_Same_Id_From_Storage()
        {
            var someTransientModel = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };

            var persisted = _sut.Persist(someTransientModel);
            var anotherWithSameId = new Question { Id = persisted.Id };
            _sut.Remove(anotherWithSameId);

            var actual = _sut.FindById(persisted.Id.Value);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Subsequent_Persist_Calls_Objects_Should_Assign_Different_Id()
        {
            var someTransientModel = new Question { Id = null, Text = "Who win super bowl", Category = new Category { Name = "Sport" } };
            var anotherTransientModel = (Question)someTransientModel.Clone();

            var result1 = _sut.Persist(someTransientModel);
            var result2 = _sut.Persist(anotherTransientModel);

            Assert.That(result1, Is.Not.Null);
            Assert.That(result2, Is.Not.Null);

            Assert.That(result1, Is.Not.SameAs(someTransientModel));
            Assert.That(result2, Is.Not.SameAs(someTransientModel));
            Assert.That(result1, Is.Not.SameAs(result2));
            Assert.That(result1.Id, Is.Not.Null);
            Assert.That(result2.Id, Is.Not.Null);
            Assert.That(result1.Id, Is.Not.EqualTo(result2.Id));
        }
    }
}