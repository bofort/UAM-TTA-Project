using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QuestionForYou.Data.Model;

namespace QuestionForYou.API.Model
{
    public class QuestionModel
    {
        public int? Id { get; set; }

        public string Text { get; set; }

        public Category Category { get; set; }

        [JsonConverter(typeof(JsonConverterCollection))]
        public ICollection<Answer> Answers { get; set; }
    }
}