﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionForYou.Data.Model;

namespace QuestionForYou.Data.Service
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        List<Category> GetAll();
    }
}
