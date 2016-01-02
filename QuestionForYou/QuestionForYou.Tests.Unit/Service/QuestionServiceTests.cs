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

    }
}
