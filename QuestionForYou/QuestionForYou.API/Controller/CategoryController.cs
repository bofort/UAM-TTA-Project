using System;
using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestionForYou.API.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _service;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <remarks>Get existing categories</remarks>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/categories")]
        [HttpGet]
        public List<CategoryModel> GetAllCategory()
        {
            var categoryList = _service.GetAll();
            return categoryList.Select(c => new CategoryModel { Id = (int)c.Id, Name = c.Name }).ToList();
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <returns>Created category</returns>
        /// <param name="category"></param>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/categories")]
        [HttpPost]
        public CategoryModel AddNewCategory(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var c = new Category
                {
                    Name = category.Name
                };
                c = _service.CreateCategory(c);
                return new CategoryModel { Id = (int)c.Id, Name = c.Name };
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
        /// Get category by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/categories/{id}")]
        [HttpGet]
        public CategoryModel GetCategory(int id)
        {
            var c = _service.FindById(id);
            if (c != null)
            {
                return new CategoryModel { Id = (int)c.Id, Name = c.Name };
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Categor not found")
                });
            }
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="id"></param>
        /// <response code="400">Bad request</response>
        /// <response code="409">Conflict</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/categories/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category q = _service.FindById(id);
            if (q != null)
            {
                _service.DeleteCategory(q);
                return Ok("Succesfully remove");
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Update category
        /// </summary>
        /// <returns>Updated category</returns>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [Route("api/categories/{id}")]
        [HttpPut]
        public CategoryModel UpdateCategory(int id, [FromBody]CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                Category c = _service.FindById(id);
                if (c != null)
                {
                    c = _service.UpdateCategory(new Category { Id = id, Name = category.Name });
                    return new CategoryModel { Id = (int)c.Id, Name = c.Name };
                }
                else
                {
                    throw new HttpResponseException(new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Content = new StringContent("Categor not found")
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


    }
}