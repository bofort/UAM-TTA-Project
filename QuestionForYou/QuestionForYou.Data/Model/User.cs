namespace QuestionForYou.Data.Model
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool HasQuestionToday { get; set; }
    }
}