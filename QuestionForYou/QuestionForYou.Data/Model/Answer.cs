using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForYou.Data.Model
{
    public class Answer : ModelBase
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
