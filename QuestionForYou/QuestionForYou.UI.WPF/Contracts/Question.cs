using QuestionForYou.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.UI.WPF.Contracts
{
    public class Question
    {
            public string Text { get; set; }
            public Category Category { get; set; }

    }
}
