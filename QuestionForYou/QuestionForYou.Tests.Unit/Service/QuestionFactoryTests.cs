﻿using FakeItEasy;
using NUnit.Framework;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using System.Collections.Generic;
using System.Linq;

namespace QuestionForYou.Tests.Unit.Service
{
    [TestFixture]
    public class QuestionFactoryTests
    {
        private QuestionFactory _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new QuestionFactory();
        }

        [Test]
        public void PrepareQuestionForUser_Should_Return_Question_With_Four_Answers()
        {
            Question question = A.Fake<Question>();

            question.Answers = new List<Answer>
            {
                 new Answer
                {
                    IsCorrect = true,
                    Text = "test"
                },
                new Answer
                {
                    IsCorrect = false,
                    Text = "test"
                },
                new Answer{
                    IsCorrect = false,
                    Text = "test"
                },
                new Answer{
                    IsCorrect = false,
                    Text = "test"
                },
                new Answer(),
                new Answer(),
                new Answer()
            };

            question = _sut.PrepareQuestionForUser(question);

            Assert.That(question.Answers.Count, Is.EqualTo(4));
        }

        [Test]
        public void PrepareQuestionForUser_Should_Return_One_Correct_Answer()
        {
            Question question = A.Fake<Question>();

            question.Answers = new List<Answer>
            {
                new Answer
                {
                    IsCorrect = true,
                    Text = "test"
                },
                new Answer
                {
                    IsCorrect = true,
                    Text = "test"
                },
                new Answer(),
                new Answer(),
                new Answer(),
                new Answer(),
                new Answer(),
                new Answer()
            };

            question = _sut.PrepareQuestionForUser(question);

            List<Answer> correctAnswers = question.Answers.Where(x => x.IsCorrect).ToList();

            Assert.That(correctAnswers.Count, Is.EqualTo(1));
        }
    }
}