using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        //[Route("api/questions")]
        //[HttpGet]
        //public QuestionModel GetRandomQuestion()
        //{
        //    var q = _service.GetRandomQuestionForUser();
        //    List<AnswerModel> a = q.Answers.Select(x => new AnswerModel { Id = x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
        //    return new QuestionModel { Id = q.Id, Category = q.Category,Answers = a, Text = q.Text };
        //}


        /// <summary>
        /// Get all questions
        /// </summary>
        /// <remarks>Get existing questions</remarks>
        /// <param name="count"></param>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/questions")]
        [HttpGet]
        public List<QuestionModel> GetAll([FromUri]int count = -1)
        {
            var questions = _service.GetAll();
            List<QuestionModel> questionModels = (from q in questions
                                                  let a = q.Answers.Select(x =>
                                                    new AnswerModel { Id = (int)x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList()
                                                  select new QuestionModel
                                                  {
                                                      Id = (int)q.Id,
                                                      Category = new CategoryModel { Id = (int)q.Category.Id, Name = q.Category.Name }
                                                  ,
                                                      Answers = a,
                                                      Text = q.Text
                                                  }).ToList();
            if (count == -1)
            {
                return questionModels;
            }
            else
            {
                return questionModels.Take(count).ToList();
            }
        }

        /// <summary>
        /// Add new question
        /// </summary>
        /// <param name="question"></param>
        /// <returns>Created question</returns>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/questions")]
        [HttpPost]
        public QuestionModel AddNewQuestion([FromBody]QuestionModel question)
        {
            if (ModelState.IsValid)
            {
                if (question.Answers.Count == 0)
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Content = new StringContent("Model is not valid")
                    });
                }
                var q = new Question
                {
                    Category = new Category { Name = question.Category.Name },
                    Text = question.Text,
                    Answers = question.Answers.Select(x => new Answer { Text = x.Text, IsCorrect = x.IsCorrect }).ToList()
                };
                q = _service.CreateQuestion(q);
                List<AnswerModel> a = q.Answers.Select(x => new AnswerModel { Id = (int)x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
                return new QuestionModel { Id = (int)q.Id, Category = new CategoryModel { Id = (int)q.Category.Id, Name = q.Category.Name }, Answers = a, Text = q.Text };
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Model is not valid")
                });
            }
        }

        /// <summary>
        /// Get one question
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/questions/{id}")]
        [HttpGet]
        public QuestionModel GetQuestionById(int id)
        {
            var q = _service.GetQuestionById(id);
            if (q != null)
            {
                List<AnswerModel> a =
                    q.Answers.Select(x => new AnswerModel { Id = (int)x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
                return new QuestionModel { Id = (int)q.Id, Category = new CategoryModel { Id = (int)q.Category.Id, Name = q.Category.Name }, Answers = a, Text = q.Text };
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Question not found")
                });
            }
        }

        /// <summary>
        /// Delete question
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
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
        /// <returns>Updated category</returns>
        /// <param name="id"></param>
        /// <param name="question"></param>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/questions/{id}")]
        [HttpPut]
        public QuestionModel UpdateQuestion(int id, [FromBody]QuestionModel question)
        {
            if (ModelState.IsValid)
            {
                Question q = _service.GetQuestionById(id);
                if (q != null)
                {
                    //List<Answer> answers =
                    //    question.Answers.Select(an => new Answer { Id = an.Id, Text = an.Text, IsCorrect = an.IsCorrect })
                    //        .ToList();
                    q = _service.UpdateQuestion(new Question { Id = id, Text = question.Text });
                    List<AnswerModel> a =
                        q.Answers.Select(x => new AnswerModel { Id = (int)x.Id, Text = x.Text, IsCorrect = x.IsCorrect }).ToList();
                    return new QuestionModel { Id = (int)q.Id, Category = new CategoryModel { Id = (int)q.Category.Id, Name = q.Category.Name }, Answers = a, Text = q.Text };
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("Question not found")
                    });
                }
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("Model is not valid")
                });
            }
        }

        /// <summary>
        /// Get category for question
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/questions/{id}/categories")]
        [HttpGet]
        public CategoryModel GetQuestionCategory(int id)
        {
            var q = _service.GetQuestionById(id);
            if (q != null)
            {
                return new CategoryModel { Id = (int)q.Category.Id, Name = q.Category.Name };
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Question not found")
                });
            }
        }

    }
}