using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using QuestionForYou.Data.Storage;

namespace QuestionForYou.API.Controller
{
    public class QuestionController : ApiController
    {

        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [Route("api/questions")]
        [HttpGet]
        public QuestionModel CreateTemplate()
        {
            var q = _service.GetRandomQuestionForUser();
            return new QuestionModel {Id = q.Id,Category = q.Category,Answers = q.Answers,Text = q.Text};
        }

    }
}
