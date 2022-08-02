using Newtonsoft.Json;

namespace Integration.Dogs.Api.Models
{
    /// <summary>
    /// Model class for The Cats API 🐶.
    /// The details of the cat.
    /// </summary>
    public class DogSearchResult
    {
        [JsonProperty("id")]
        public string Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("temperament")]
        public string Temperament { get; internal set; }

        #region == Dog Specific Properties ==

        [JsonProperty("bred_for")]
        public string BredFor { get; internal set; }

        [JsonProperty("breed_group")]
        public string BreedGroup { get; internal set; }
        #endregion
    }
}
