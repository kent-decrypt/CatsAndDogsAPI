using Newtonsoft.Json;

namespace Integration.Cats.Api.Models
{
    /// <summary>
    /// Model class for The Cats API 🐱.
    /// The details of the cat from search
    /// </summary>
    public class CatSearchResult
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("temperament")]
        public string Temperament { get; internal set; }

        [JsonProperty("origin")]
        public string Origin { get; internal set; }

        #region == Cat Specific Properties ==

        [JsonProperty("country_code")]
        public string CountryCode { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }
        #endregion
    }
}
