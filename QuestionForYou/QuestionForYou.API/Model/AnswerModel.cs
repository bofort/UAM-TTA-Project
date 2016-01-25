using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace QuestionForYou.API.Model
{
    public class AnswerModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "questionId")]
        public int QuestionId { get; set; }

        [MaxLength(100)]
        [Required]
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }

        [Required]
        [JsonProperty(PropertyName = "isCorrect", Required = Required.Always)]
        public bool IsCorrect { get; set; }
    }
}