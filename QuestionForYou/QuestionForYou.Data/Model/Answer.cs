using System.ComponentModel.DataAnnotations.Schema;

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