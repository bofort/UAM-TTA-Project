using Newtonsoft.Json;

namespace QuestionForYou.API.Model
{
    public class AnswerModel
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "questionId")]
        public int QuestionId { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "isCorrect")]
        public bool IsCorrect { get; set; }
    }
}