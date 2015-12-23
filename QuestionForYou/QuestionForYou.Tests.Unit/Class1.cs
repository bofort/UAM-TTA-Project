using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace QuestionForYou.Tests.Unit
{
    [TestFixture]
    public class Class1
    {


        [Test]
        public void GetBool_Return_True()
        {
            QuestionForYou.Data.Class1 c1 = new QuestionForYou.Data.Class1();
            bool result = c1.GetBool();
            Assert.That(result,Is.EqualTo(true));
        }


    }
}
