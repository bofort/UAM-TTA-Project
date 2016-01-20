using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;

namespace QuestionForYou.API.Controller
{
    public class AnswerController : ApiController
    {

        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        [Route("api/questions/answers/{id}")]
        [HttpGet]
        public List<AnswerModel> GetAnswersForQuestion(int id)
        {
            List<Answer> answers = _service.GetAnswersForQuestion(id);
            return answers.Select(x=> new AnswerModel {Id=x.Id,Text = x.Text,IsCorrect = x.IsCorrect}).ToList();
        }

        [Route("api/answers")]
        [HttpPost]
        public AnswerModel AddNewAnswer(AnswerModel answer)
        {
            var a = new Answer
            {
                Text = answer.Text,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId
            };
            a = _service.CreateAnswer(a);
            return new AnswerModel { Id = a.Id, Text = a.Text, IsCorrect = a.IsCorrect };
        }

    }
}
