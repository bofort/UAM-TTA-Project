using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NUnit.Framework;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.Tests.Integration.Storage
{
    [TestFixture]
    public class RepositoryTests
    {

        private static Func<QuestionForYouContext> _dbContextFactory;
        private Repository<Account> _sut;
        private TransactionScope _scope;

        [SetUp]
        public void SetUp()
        {
            _sut = new Repository<Account>(_dbContextFactory);
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



    }
}
