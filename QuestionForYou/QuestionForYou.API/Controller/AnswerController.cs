using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QuestionForYou.API.Controller
{
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Route("api/questions/answers/{id}")]
        //[HttpGet]
        //public List<AnswerModel> GetAnswersForQuestion(int id)
        //{
        //    List<Answer> answers = _service.GetAnswersForQuestion(id);
        //    return answers.Select(x => new AnswerModel { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        //[Route("api/answers")]
        //[HttpPost]
        //public AnswerModel AddNewAnswer(AnswerModel answer)
        //{
        //    var a = new Answer
        //    {
        //        Text = answer.Text,
        //        IsCorrect = answer.IsCorrect,
        //        QuestionId = answer.QuestionId
        //    };
        //    a = _service.CreateAnswer(a);
        //    return new AnswerModel { Id = a.Id, Text = a.Text, IsCorrect = a.IsCorrect };
        //}
    }
}