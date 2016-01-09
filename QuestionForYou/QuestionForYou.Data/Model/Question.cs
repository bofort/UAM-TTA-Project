using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.Data.Model
{
    public class Question : ModelBase
    {

        public Question()
        { 
        }

        public string Text { get; set; }
        public Category Category { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
