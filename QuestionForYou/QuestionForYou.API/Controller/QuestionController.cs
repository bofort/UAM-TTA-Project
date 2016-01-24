using System.Collections.Generic;
using System.Linq;
using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using System.Web.Http;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;

namespace QuestionForYou.API.Controller
{
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _service;
        private readonly ICategoryService _categoryService;

        public QuestionController(IQuestionService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[Route("api/questions")]
        //[HttpGet]
        //public QuestionModel GetRandomQuestion()
        //{
        //    var q = _service.GetRandomQuestionForUser();
        //    List<AnswerModel> a = q.Answers.Select(x => new AnswerModel { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
        //    return new QuestionModel { Id = q.Id, Category = q.Category,Answers = a, Text = q.Text };
        //}


        /// <summary>
        /// Get all question
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var questions = _service.GetAll();
            List<QuestionModel> questionModels = (from q in questions let a = q.Answers.Select(x => 
                                                    new AnswerModel {Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect}).ToList()
                                                  select new QuestionModel {Id = q.Id, Category = new CategoryModel { Id = q.Category.Id, Name = q.Category.Name }
                                                  , Answers = a, Text = q.Text}).ToList();
            return Ok(questionModels);
        }

        /// <summary>
        /// Add new question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions")]
        [HttpPost]
        public IHttpActionResult AddNewQuestion([FromBody]QuestionModel question)
        {
            List<Answer> asd = question.Answers.Select(x => new Answer {  Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
            var q = new Question
            {
                Category = new Category {Name = question.Category.Name},
                Text = question.Text,
                Answers = asd
            };
            q = _service.CreateQuestion(q);
            List<AnswerModel> a = q.Answers.Select(x => new AnswerModel { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
            return Ok(new QuestionModel { Id = q.Id, Category = new CategoryModel{Id = q.Category.Id,Name = q.Category.Name}, Answers = a, Text = q.Text });
        }

        /// <summary>
        /// Get one question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions/{id}")]
        [HttpGet]
        public IHttpActionResult GetQuestionById(int id)
        {
            var q = _service.GetQuestionById(id);
            if (q != null)
            {
                List<AnswerModel> a =
                    q.Answers.Select(x => new AnswerModel {Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect}).ToList();
                return Ok(new QuestionModel {Id = q.Id, Category = new CategoryModel { Id = q.Category.Id, Name = q.Category.Name }, Answers = a, Text = q.Text});
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            Question q = _service.GetQuestionById(id);
            if (q != null)
            {
                _service.DeleteQuestion(q);
                return Ok("Succesfully remove");
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Update question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateQuestion(int id,[FromBody]QuestionModel question)
        {
            Question q = _service.GetQuestionById(id);
            if (q != null)
            {
                List<Answer> answers =
                    question.Answers.Select(an => new Answer {Id = an.Id, Text = an.Text, IsCorrect = an.IsCorrect})
                        .ToList();
                    q = _service.UpdateQuestion(new Question {Id = id,Category = new Category {  Name = q.Category.Name }, Text = question.Text,Answers = answers });
                List<AnswerModel> a =
                    q.Answers.Select(x => new AnswerModel { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
                return Ok(new QuestionModel { Id = q.Id, Category = new CategoryModel { Id = q.Category.Id, Name = q.Category.Name }, Answers = a, Text = q.Text });
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Get category for question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/questions/{id}/categories")]
        [HttpGet]
        public IHttpActionResult GetQuestionCategory(int id)
        {
            var q = _service.GetQuestionById(id);
            if (q != null)
            {
                return Ok(new CategoryModel { Id = q.Category.Id, Name = q.Category.Name });
            }
            else
            {
                return NotFound();
            }
        }

    }
}