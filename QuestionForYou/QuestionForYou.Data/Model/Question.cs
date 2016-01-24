using System.Collections.Generic;

namespace QuestionForYou.Data.Model
{
    public class Question : ModelBase
    {
        public string Text { get; set; }
        public Category Category { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}