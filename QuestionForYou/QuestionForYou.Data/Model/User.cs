using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.Data.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool HasQuestionToday { get; set; }
    }
}
