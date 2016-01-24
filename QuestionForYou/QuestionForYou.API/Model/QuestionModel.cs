using Newtonsoft.Json;
using QuestionForYou.Data.Model;
using System.Collections.Generic;

namespace QuestionForYou.API.Model
{
    public class QuestionModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "category")]
        public CategoryModel Category { get; set; }

        //[JsonConverter(typeof(JsonConverterCollection))]
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "answers")]
        public ICollection<AnswerModel> Answers { get; set; }
    }
}