using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace QuestionForYou.API.Model
{
    public class CategoryModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }
    }
}