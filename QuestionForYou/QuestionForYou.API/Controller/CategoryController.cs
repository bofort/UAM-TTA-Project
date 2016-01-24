using QuestionForYou.API.Model;
using QuestionForYou.Data.Model;
using QuestionForYou.Data.Service;
using System.Collections.Generic;
using System.Linq;
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
        /// <returns></returns>
        [Authorize]
        [Route("api/categories")]
        [HttpGet]
        public IHttpActionResult GetAllCategory()
        {
            var categoryList = _service.GetAll();
            return Ok(categoryList.Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList());
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/categories")]
        [HttpPost]
        public IHttpActionResult AddNewCategory(CategoryModel category)
        {
            var c = new Category
            {
                Name = category.Name
            };
            c = _service.CreateCategory(c);
            return Ok(new CategoryModel { Id = c.Id, Name = c.Name });
        }

        /// <summary>
        /// Get category by id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("api/categories/{id}")]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var c = _service.FindById(id);
            if (c != null)
            {
                return Ok(new CategoryModel { Id = c.Id, Name = c.Name });
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete category
        /// </summary>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [Authorize]
        [Route("api/categories/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, [FromBody]CategoryModel category)
        {
            Category c = _service.FindById(id);
            if (c != null)
            {
                c = _service.UpdateCategory(new Category { Id = id, Name = category.Name });
                return Ok(new CategoryModel { Id = c.Id, Name = c.Name });
            }
            else
            {
                return NotFound();
            }
        }


    }
}