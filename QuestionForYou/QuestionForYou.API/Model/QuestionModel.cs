using Newtonsoft.Json;
using QuestionForYou.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuestionForYou.API.Model
{
    public class QuestionModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [JsonProperty(PropertyName = "text", Required = Required.Always)]
        public string Text { get; set; }

        [Required]
        [JsonProperty(PropertyName = "category")]
        public CategoryModel Category { get; set; }

        [Required]
        [JsonProperty(PropertyName = "answers")]
        public ICollection<AnswerModel> Answers { get; set; }
    }
}