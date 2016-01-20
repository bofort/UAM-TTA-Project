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
    public class CategoryController : ApiController
    {

        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [Route("api/categories")]
        [HttpGet]
        public List<CategoryModel> GetAllCategory()
        {
            var categoryList = _service.GetAll();
            return categoryList.Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
        }

        [Route("api/categories")]
        [HttpPost]
        public CategoryModel AddNewQuestion(CategoryModel category)
        {
            var c = new Category
            {
                Name = category.Name
            };
            c = _service.CreateCategory(c);
            return new CategoryModel { Id = c.Id, Name = c.Name};
        }

    }
}
