using Newtonsoft.Json;

namespace QuestionForYou.API.Model
{
    public class CategoryModel
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}