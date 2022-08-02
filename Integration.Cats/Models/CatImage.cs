using Newtonsoft.Json;

namespace Integration.Cats.Api.Models
{
    /// <summary>
    /// Model class for the cat's Image Properties🐱
    /// </summary>
    public class CatImage
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("width")]
        public int? Width { get; internal set; }

        [JsonProperty("height")]
        public int? Height { get; internal set; }

        [JsonProperty("url")]
        public string Url { get; internal set; }
    }
}
