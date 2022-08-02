using Newtonsoft.Json;

namespace Integration.Cats.Api.Models
{
    /// <summary>
    /// Model class for The Cats API 🐱.
    /// The details of the cat.
    /// </summary>
    public class Cat
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("temperament")]
        public string Temperament { get; internal set; }

        [JsonProperty("origin")]
        public string Origin { get; internal set; }

        [JsonProperty("image")]
        public CatImage Image { get; internal set; }

        #region == Cat Specific Properties ==

        [JsonProperty("country_code")]
        public string CountryCode { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }
        #endregion
    }
}
